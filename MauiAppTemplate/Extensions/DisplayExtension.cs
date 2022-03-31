using MauiAppTemplate.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;

namespace MauiAppTemplate.Extensions
{
    public static class DisplayExtension
    {
        /// <summary>
        /// Get the all display attribute of an object
        /// </summary>
        public static DisplayAttribute GetDisplayAttribute(this object obj)
        {
            if (obj == null)
                throw new ArgumentNullException();

            if (obj.GetType().GetField(obj.ToString()).GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() is DisplayAttribute da)
                return da;
            else
                throw new Exception();
        }

        /// <summary>
        /// Get specific property of a display attribute
        /// If attribute resource type is set, the value of the property is retrieved from the resource file
        /// </summary>
        public static string GetDisplayAttribute(this object obj, AttributeProperty attributeProperty = AttributeProperty.Name)
        {
            if (obj == null)
                throw new ArgumentNullException();

            DisplayAttribute displayAttribute = obj.GetDisplayAttribute();

            ResourceManager resourceManager = null;
            if (displayAttribute.ResourceType != null)
                resourceManager = new ResourceManager(displayAttribute.ResourceType);

            return attributeProperty switch
            {
                AttributeProperty.Name => displayAttribute.ResourceType != null ? resourceManager.GetString(displayAttribute.Name) : displayAttribute.Name,
                AttributeProperty.Description => displayAttribute.ResourceType != null ? resourceManager.GetString(displayAttribute.Description) : displayAttribute.Description,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
