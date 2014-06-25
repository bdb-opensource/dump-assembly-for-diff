# dump-assembly-for-diff


Dump .NET assemblies to text so you can compare them with your favorite diff tool

It can be used in conjunction with .gitattributes to allow diffing assembly binaries when using git (useful for verifying deployments that use git).

## Usage

Just pass it the name of a .dll/.exe file, and it will output some text:

`DumpAssemblyForDiff.exe <my_assembly.dll/exe>`

### Example output

Here's the output of running `DumpAssemblyForDiff` on itself:

	Assembly: DumpAssemblyForDiff, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
		Custom Attributes:
			System.Diagnostics.DebuggableAttribute
				<unresolved>
			System.Reflection.AssemblyCompanyAttribute
				<unresolved>
			System.Reflection.AssemblyConfigurationAttribute
				<unresolved>
			System.Reflection.AssemblyCopyrightAttribute
				<unresolved>
			System.Reflection.AssemblyDescriptionAttribute
				<unresolved>
			System.Reflection.AssemblyFileVersionAttribute
				<unresolved>
			System.Reflection.AssemblyProductAttribute
				<unresolved>
			System.Reflection.AssemblyTitleAttribute
				<unresolved>
			System.Reflection.AssemblyTrademarkAttribute
				<unresolved>
			System.Runtime.CompilerServices.CompilationRelaxationsAttribute
				<unresolved>
			System.Runtime.CompilerServices.RuntimeCompatibilityAttribute
				<unresolved>
			System.Runtime.InteropServices.ComVisibleAttribute
				<unresolved>
			System.Runtime.InteropServices.GuidAttribute
				<unresolved>
			System.Runtime.Versioning.TargetFrameworkAttribute
				<unresolved>
		Modules:
			Module: C:\source\bdb\submodules\components\tools\DumpAssemblyForDiff\bin\DumpAssemblyForDiff.exe
				Assembly References:
					Mono.Cecil, Version=0.9.5.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756
					mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
					System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
				Types:
					<Module>
					DumpAssemblyForDiff.Program
						Methods:
							System.String DumpAssemblyForDiff.Program::<DumpCustomAttributes>b__12(Mono.Cecil.CustomAttribute)
							System.String DumpAssemblyForDiff.Program::<DumpType>b__6(Mono.Cecil.TypeReference)
							System.String DumpAssemblyForDiff.Program::<DumpType>b__7(Mono.Cecil.MethodDefinition)
							System.String DumpAssemblyForDiff.Program::<DumpType>b__8(Mono.Cecil.PropertyDefinition)
							System.String DumpAssemblyForDiff.Program::<DumpType>b__9(Mono.Cecil.FieldDefinition)
							System.String DumpAssemblyForDiff.Program::<DumpType>b__a(Mono.Cecil.EventDefinition)
							System.String DumpAssemblyForDiff.Program::<DumpType>b__b(Mono.Cecil.TypeDefinition)
							System.String DumpAssemblyForDiff.Program::<Main>b__0(Mono.Cecil.ModuleDefinition)
							System.String DumpAssemblyForDiff.Program::<Main>b__1(Mono.Cecil.AssemblyNameReference)
							System.String DumpAssemblyForDiff.Program::<Main>b__2(Mono.Cecil.TypeDefinition)
							System.Void DumpAssemblyForDiff.Program::.cctor()
							System.Void DumpAssemblyForDiff.Program::.ctor()
							System.Void DumpAssemblyForDiff.Program::DumpCustomAttributes(Mono.Cecil.ICustomAttributeProvider)
							System.Void DumpAssemblyForDiff.Program::DumpType(Mono.Cecil.TypeDefinition)
							System.Void DumpAssemblyForDiff.Program::Main(System.String[])
							System.Void DumpAssemblyForDiff.Program::Out(System.String,System.Object[])
						Fields:
							System.Func`2<Mono.Cecil.AssemblyNameReference,System.String> DumpAssemblyForDiff.Program::CS$<>9__CachedAnonymousMethodDelegate4
							System.Func`2<Mono.Cecil.CustomAttribute,System.String> DumpAssemblyForDiff.Program::CS$<>9__CachedAnonymousMethodDelegate13
							System.Func`2<Mono.Cecil.EventDefinition,System.String> DumpAssemblyForDiff.Program::CS$<>9__CachedAnonymousMethodDelegate10
							System.Func`2<Mono.Cecil.FieldDefinition,System.String> DumpAssemblyForDiff.Program::CS$<>9__CachedAnonymousMethodDelegatef
							System.Func`2<Mono.Cecil.MethodDefinition,System.String> DumpAssemblyForDiff.Program::CS$<>9__CachedAnonymousMethodDelegated
							System.Func`2<Mono.Cecil.ModuleDefinition,System.String> DumpAssemblyForDiff.Program::CS$<>9__CachedAnonymousMethodDelegate3
							System.Func`2<Mono.Cecil.PropertyDefinition,System.String> DumpAssemblyForDiff.Program::CS$<>9__CachedAnonymousMethodDelegatee
							System.Func`2<Mono.Cecil.TypeDefinition,System.String> DumpAssemblyForDiff.Program::CS$<>9__CachedAnonymousMethodDelegate11
							System.Func`2<Mono.Cecil.TypeDefinition,System.String> DumpAssemblyForDiff.Program::CS$<>9__CachedAnonymousMethodDelegate5
							System.Func`2<Mono.Cecil.TypeReference,System.String> DumpAssemblyForDiff.Program::CS$<>9__CachedAnonymousMethodDelegatec
							System.Int32 DumpAssemblyForDiff.Program::tab

