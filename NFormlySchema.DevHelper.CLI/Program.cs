﻿using System;
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



    public class SampleForm
    {
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("OrderBy")]
        public int? OrderBy { get; set; }

        public string[] BasicCollection { get; set; }

        [FieldGroup(ClassName = "TheAddress")]
        public Address TheAddress { get; set; }

        public class Address
        {

            [DisplayName("Street")]
            public string Street { get; set; }


            [DisplayName("City")]
            public string City { get; set; }
        }

    }
}