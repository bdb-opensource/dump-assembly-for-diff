using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Mono.Cecil;

namespace DumpAssemblyForDiff
{
    class Program
    {
        static void Main(string[] args)
        {
            Environment.ExitCode = 0;
            if (args.Length < 1)
            {
                Console.Error.WriteLine(String.Format("Usage: {0} files...",
                                            System.Reflection.Assembly.GetExecutingAssembly().Location));
                Environment.ExitCode = -1;
                return;
            }
            var fileNames = args.Select(Path.GetFullPath);
            foreach (var fileName in fileNames)
            {
                var assembly = AssemblyDefinition.ReadAssembly(fileName);
                Out("Assembly: {0}", assembly.FullName);
                tab++;

                DumpCustomAttributes(assembly);

                Out("Modules:");
                tab++;
                foreach (var module in assembly.Modules.OrderBy(x => x.FullyQualifiedName))
                {
                    Out("Module: {0}", module.FullyQualifiedName);
                    tab++;

                    Out("Assembly References:");
                    tab++;
                    foreach (var reference in module.AssemblyReferences.OrderBy(x => x.FullName))
                    {
                        Out(reference.FullName);
                    }
                    tab--;

                    Out("Types:");
                    tab++;
                    foreach (var type in module.Types.OrderBy(x => x.FullName))
                    {
                        DumpType(type);
                    }
                    tab--;

                    tab--;

                }
                tab--;
                tab--;
            }
        }

        private static void DumpType(TypeDefinition type)
        {
            Out(type.FullName);

            tab++;

            if (type.HasInterfaces)
            {
                Out("Interfaces:");
                tab++;
                foreach (var iface in type.Interfaces.OrderBy(x => x.FullName))
                {
                    Out(iface.FullName);
                }
                tab--;
            }

            if (type.HasMethods)
            {
                Out("Methods:");
                tab++;
                foreach (var method in type.Methods.OrderBy(x => x.FullName))
                {
                    Out(method.FullName);
                }
                tab--;
            }

            if (type.HasProperties)
            {
                Out("Properties:");
                tab++;
                foreach (var prop in type.Properties.OrderBy(x => x.FullName))
                {
                    Out(prop.FullName);
                }
                tab--;
            }

            if (type.HasFields)
            {
                Out("Fields:");
                tab++;
                foreach (var field in type.Fields.OrderBy(x => x.FullName))
                {
                    Out(field.FullName);
                }
                tab--;
            }

            if (type.HasEvents)
            {
                Out("Events:");
                tab++;
                foreach (var ev in type.Events.OrderBy(x => x.FullName))
                {
                    Out(ev.FullName);
                }
                tab--;
            }

            DumpCustomAttributes(type);

            if (type.HasNestedTypes)
            {
                Out("Nested Types:");
                tab++;
                foreach (var ev in type.NestedTypes.OrderBy(x => x.FullName))
                {
                    DumpType(ev);
                }
                tab--;
            }

            tab--;
        }

        private static void DumpCustomAttributes(Mono.Cecil.ICustomAttributeProvider customAttributeProvider)
        {
            if (!customAttributeProvider.HasCustomAttributes)
            {
                return;
            }
            Out("Custom Attributes:");
            tab++;
            foreach (var ev in customAttributeProvider.CustomAttributes.OrderBy(x => x.AttributeType.FullName))
            {
                Out(ev.AttributeType.FullName);

                if (false == ev.IsResolved)
                {
                    tab++;
                    Out("<unresolved>");
                    tab--;
                    continue;
                }

                tab++;

                if (ev.HasConstructorArguments)
                {
                    Out("Parameters:");
                    tab++;
                    foreach (var param in ev.ConstructorArguments)
                    {
                        Out("({0})({1})", param.Type.FullName, param.Value is String ? "\"" + param.Value + "\"" : param.Value);
                    }
                    tab--;
                }

                tab--;
            }
            tab--;
        }

        private static int tab = 0;

        static void Out(string format, params object[] args)
        {
            for (int i = 0; i < tab; i++ )
            {
                Console.Out.Write("    ");
            }
            Console.Out.WriteLine(args.Length > 0 ? String.Format(format, args) : format);
            Console.Out.Flush();
        }
    }
}
