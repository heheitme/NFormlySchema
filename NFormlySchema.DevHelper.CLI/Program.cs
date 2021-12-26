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
            var formly_test_json = @"C:\Users\Admin\source\repos\NFormlySchema\NFormlySchema.DevHelper.CLI\FormlyTesting\src\formly.test.json";

            var formly = NFormlySchema.FormlySchema.FromType<SampleForm>();


            Console.WriteLine(formly.ToJson(Newtonsoft.Json.Formatting.Indented));
            File.WriteAllText(formly_test_json, formly.ToJson());
        }
    }



    class SampleForm
    {
        [DisplayName]
        public string Name { get; set; }

        [DisplayName]
        public int? OrderBy { get; set; }

        [DisplayName]
        [FieldGroup(ClassName = "Some Name Here")]
        public string[] BasicCollection { get; set; }
    }
}
