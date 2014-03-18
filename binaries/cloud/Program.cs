using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using Microsoft.CSharp;
using System.CodeDom.Compiler;

namespace cloud
{
    class Program
    {
        static Program p = new Program();
        static void Main(string[] args)
        {
            string compiler_result = "";
            if(args.Length>0)
            if (args[0] != "")
            {
                switch (args[0])
                {
                    case "ess": Console.Write("success");
                                break;
                    case "eshant": 
                                string  strs = p.getList("cloud");
                                Console.WriteLine(strs);
                                break;
                    case "cs":
                                string program = args[1];
                                string user = args[2];
                                var base64EncodedBytes = System.Convert.FromBase64String(program);
                                program = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                                compiler_result = p.execCode(program,user);
                                break;
                }
                
                
            }
            if (compiler_result != "")
            {
                Console.Write(compiler_result);
                return;
            }
            //Console.WriteLine(s);
           // Console.Read();
        }
        public string getList(string path)
        {
            
            try
            {
                string[] filePaths = Directory.GetFiles(@"cloud\", "*.*", SearchOption.AllDirectories);
                return p.Json(filePaths);
            }
            catch (Exception e)
            {
                Console.WriteLine("not found");
                return "";
            }
            

        }
        public string Json(string[] data)
        {
            string json = "{";
            int i = 0;
            foreach (string str in data)
            { 
                json +=i.ToString()+":"+str;
                if (i != data.Count() - 1)
                {
                    json += ",";
                }
                i++;
            }
            json += "}";
            return json;
        }
        public string execCode(string program,string user)
        {
            //Console.WriteLine("In");
            var csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v3.5" } });
            var parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" }, "csharp\\"+user+".exe", true);
            parameters.GenerateExecutable = true;
      
            CompilerResults results = csc.CompileAssemblyFromSource(parameters,
            program);
            string res = "Errors : \n";
            //Console.WriteLine(program);
            if (results.Errors.Count > 0)
            {
                Console.WriteLine("err");
                results.Errors.Cast<CompilerError>().ToList().ForEach(
                    error => res += error.ErrorText + "\n");
                return res;
            }
            else
                return "success";
          
        }
        
    }
}
