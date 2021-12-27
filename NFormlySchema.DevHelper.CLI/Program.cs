using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace NFormlySchema.DevHelper.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            pretifyJsonArrayForTestCase(@"C:\Users\Admin\Desktop\JsonToParse.json");



            var formly_test_json = @"C:\Users\Admin\source\repos\NFormlySchema\NFormlySchema.DevHelper.CLI\FormlyTesting\src\formly.test.json";

            var formly = NFormlySchema.FormlySchema.FromType<SampleForm>();


            Console.WriteLine(formly.ToJson(Newtonsoft.Json.Formatting.Indented));
            File.WriteAllText(formly_test_json, formly.ToJson());
        }

        private static void pretifyJsonArrayForTestCase(string fileToJson)
        {
            var content = File.ReadAllText(fileToJson);
            var jArr = JArray.Parse(content);

            SaveJsonObjectPretify(fileToJson, jArr);
        }
        static void SaveJsonObjectPretify(string fileToJson, object obj) =>
            File.WriteAllText(fileToJson, JsonConvert.SerializeObject(obj, Formatting.Indented));


    }



    public class SampleForm
    {
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("OrderBy")]
        public int? OrderBy { get; set; }

        public string[] BasicCollection { get; set; }

        [FieldGroup(ClassName = "TheAddress")]
        public Address TheAddressList { get; set; }


        public class Address
        {

            [DisplayName("Street")]
            public string Street { get; set; }


            [DisplayName("City")]
            public string City { get; set; }
        }

    }
}
