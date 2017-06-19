﻿using System;
using Newtonsoft.Json;

namespace Yelp.Api.Web.Models
{
    public class Category : IEquatable<Category>
    {
        #region Properties

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("alias")]
        public string Alias { get; set; }

        #endregion

        #region Methods

        public bool Equals(Category other)
        {
            if (other == null)
                return false;

            if (Alias != null && Alias.Equals(other.Alias, StringComparison.CurrentCultureIgnoreCase))
                return true;
            else
                return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Category category = obj as Category;
            if (category == null)
                return false;
            else
                return Equals(category);
        }

        public override int GetHashCode()
        {
            return Alias?.GetHashCode() ?? base.GetHashCode();
        }

        public static bool operator ==(Category category1, Category category2)
        {
            if (((object)category1) == null || ((object)category2) == null)
                return Object.Equals(category1, category2);

            return category1.Equals(category2);
        }

        public static bool operator !=(Category category1, Category category2)
        {
            if (((object)category1) == null || ((object)category2) == null)
                return !Object.Equals(category1, category2);

            return !(category1.Equals(category2));
        }

        #endregion
    }
}