﻿/*
   Copyright 2011 - 2023 Adrian Popescu

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Redmine.Net.Api.Internals;
using Redmine.Net.Api.Serialization;

namespace Redmine.Net.Api.Types
{
    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    [XmlRoot(RedmineKeys.FIELD)]
    #pragma warning disable CA1711
    public sealed class Field : IXmlSerializable, IJsonSerializable, IEquatable<Field>
    #pragma warning restore CA1711
    {
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public string Info { get; internal set; }
        #endregion

        #region Implementation of IXmlSerializable

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public XmlSchema GetSchema() { return null; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        public void ReadXml(XmlReader reader)
        {
            reader.Read();
            if (reader.NodeType == XmlNodeType.Text)
            {
                Info = reader.Value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        public void WriteXml(XmlWriter writer) { }

        #endregion

        #region Implementation of IJsonSerialization
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        public void ReadJson(JsonReader reader)
        {
            if (reader.TokenType == JsonToken.String)
            {
                Info = reader.Value.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        public void WriteJson(JsonWriter writer) { }
        #endregion

        #region Implementation of IEquatable<Field>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Field other)
        {
            return other != null && Info == other.Info;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as Field);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 13;
                hashCode = HashCodeHelper.GetHashCode(Info, hashCode);
                return hashCode;
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string DebuggerDisplay => $"[{nameof(Field)}: {Info}]";

    }
}