using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ex03.GarageLogic.Garage
{
    public class DefiningPropertiesDictionary
    {
        private readonly Dictionary<string, string> r_StringValuesByDefiningProperty;

        public DefiningPropertiesDictionary()
        {
            r_StringValuesByDefiningProperty = new Dictionary<string, string>();
        }

        public T GetParsedValueForDefiningProperty<T>(string i_PropertyName)
        {
            const string k_TryParseMethodName = "TryParse";
            const int k_OutParameterIndex = 1;
            T propertyValue = default;
            Type[] tryParseTypes = { typeof(string), typeof(T).MakeByRefType() };
            MethodInfo tryParseMethod = typeof(T).GetMethod(k_TryParseMethodName, tryParseTypes);
            bool isTParsable = tryParseMethod != null;

            if (isTParsable)
            {
                string propertyValueString = GetValueStringForDefiningProperty(i_PropertyName);
                object[] tryParseParameters = new object[] { propertyValueString, null };
                bool successfulParse = (bool)tryParseMethod.Invoke(propertyValueString, tryParseParameters);

                if (successfulParse)
                {
                    propertyValue = (T)tryParseParameters[k_OutParameterIndex];
                }
                else
                {
                    throwExceptionForFailedParseOfDefiningProperty(i_PropertyName, typeof(T).Name);
                }
            }
            else
            {
                throwExceptionForNonParsableGeneric(typeof(T).Name);
            }

            return propertyValue;
        }

        public string GetValueStringForDefiningProperty(string i_PropertyName)
        {
            string propertyValueString = null;
            bool successfulSearch = r_StringValuesByDefiningProperty.TryGetValue(
                i_PropertyName,
                out propertyValueString);

            if (!successfulSearch)
            {
                throwExceptionForMissingDefiningProperty(i_PropertyName);
            }

            return propertyValueString;
        }

        public void AddValueStringForDefiningProperty(string i_PropertyName, string i_ValueStringToBeSet)
        {
            if (!r_StringValuesByDefiningProperty.ContainsKey(i_PropertyName))
            {
                r_StringValuesByDefiningProperty.Add(i_PropertyName, i_ValueStringToBeSet);
            }
            else
            {
                throwExceptionForAlreadyExistingDefiningProperty(i_PropertyName);
            }
        } 

        private static void throwExceptionForMissingDefiningProperty(string i_PropertyName)
        {
            string missingPropertyMessage = $"Defining property {i_PropertyName} is missing";

            throw new ArgumentException(missingPropertyMessage);
        }

        private static void throwExceptionForAlreadyExistingDefiningProperty(string i_PropertyName)
        {
            string alreadyExistingPropertyMessage = $"Defining property {i_PropertyName} already exists in dictionary";

            throw new ArgumentException(alreadyExistingPropertyMessage);
        }

        private static void throwExceptionForNonParsableGeneric(string i_TypeName)
        {
            string nonParsableGenericMessage = $"Type {i_TypeName} is not parsable";

            throw new ArgumentException(nonParsableGenericMessage);
        }

        private static void throwExceptionForFailedParseOfDefiningProperty(string i_PropertyName, string i_TypeName)
        {
            string failedParseMessage =
                $"Value provided for property {i_PropertyName} could not be parsed to {i_TypeName}";

            throw new FormatException(failedParseMessage);
        }
    }
}