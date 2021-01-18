C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild .\WPF\NeuroSpeech.UIAtoms\NeuroSpeech.UIAtoms.sln /t:Build /p:Configuration=Release
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild .\WPF\NeuroSpeech.UIAtoms\NeuroSpeech.UIAtoms.sln /t:Build /p:Configuration=ReleaseDemo
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild .\WPF\NeuroSpeech.UIAtoms\NeuroSpeech.UIAtoms.sln /t:Build /p:Configuration=Debug
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild .\WPF\NeuroSpeech.UIAtoms\NeuroSpeech.UIAtoms.sln /t:Build /p:Configuration=DebugDemo
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild .\WPF\NeuroSpeech.UIAtoms\NeuroSpeech.UIAtoms.sln /t:Build /p:Configuration=Release4
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild .\WPF\NeuroSpeech.UIAtoms\NeuroSpeech.UIAtoms.sln /t:Build /p:Configuration=ReleaseDemo4
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild .\WPF\NeuroSpeech.UIAtoms\NeuroSpeech.UIAtoms.sln /t:Build /p:Configuration=Debug4
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild .\WPF\NeuroSpeech.UIAtoms\NeuroSpeech.UIAtoms.sln /t:Build /p:Configuration=DebugDemo4
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild .\Silverlight\NeuroSpeech.UIAtoms\NeuroSpeech.UIAtoms.Silverlight.sln /t:Build /p:Configuration=Release
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild .\Silverlight\NeuroSpeech.UIAtoms\NeuroSpeech.UIAtoms.Silverlight.sln /t:Build /p:Configuration=ReleaseDemo
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild .\Silverlight\NeuroSpeech.UIAtoms\NeuroSpeech.UIAtoms.Silverlight.sln /t:Build /p:Configuration=Debug
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild .\Silverlight\NeuroSpeech.UIAtoms\NeuroSpeech.UIAtoms.Silverlight.sln /t:Build /p:Configuration=DebugDemo
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild .\Silverlight\NeuroSpeech.UIAtoms\NeuroSpeech.UIAtoms.Silverlight.sln /t:Build /p:Configuration=Release5
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild .\Silverlight\NeuroSpeech.UIAtoms\NeuroSpeech.UIAtoms.Silverlight.sln /t:Build /p:Configuration=ReleaseDemo5
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild .\Silverlight\NeuroSpeech.UIAtoms\NeuroSpeech.UIAtoms.Silverlight.sln /t:Build /p:Configuration=Debug5
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild .\Silverlight\NeuroSpeech.UIAtoms\NeuroSpeech.UIAtoms.Silverlight.sln /t:Build /p:Configuration=DebugDemo5
"%VS100COMNTOOLS%\..\IDE\devenv" .\Setup\UIAtoms2010\UIAtoms2010.sln /build "Debug"
"C:\Program Files\7-Zip\7z.exe" a .\Setup\UIAtomsDemo.zip .\Setup\UIAtoms2010\UIAtoms2010Demo\Debug\setup.exe .\Setup\UIAtoms2010\UIAtoms2010Demo\Debug\UIAtomsDemo.msi
"C:\Program Files\7-Zip\7z.exe" a .\Setup\UIAtomsForWPF.zip .\Setup\UIAtoms2010\UIAtoms2010ForWPF\Debug\setup.exe .\Setup\UIAtoms2010\UIAtoms2010ForWPF\Debug\UIAtomsForWPF.msi
"C:\Program Files\7-Zip\7z.exe" a .\Setup\UIAtomsForSL.zip .\Setup\UIAtoms2010\UIAtomsForSL\Debug\setup.exe .\Setup\UIAtoms2010\UIAtomsForSL\Debug\UIAtomsForSL.msi
"C:\Program Files\7-Zip\7z.exe" a .\Setup\UIAtomsSuite.zip .\Setup\UIAtoms2010\UIAtomsSuite\Debug\setup.exe .\Setup\UIAtoms2010\UIAtomsSuite\Debug\UIAtomsSuite.msi
"C:\Program Files\7-Zip\7z.exe" a .\Setup\UIAtomsSuiteSourceCode.zip .\Setup\UIAtoms2010\UIAtomsSuite\Debug\setup.exe .\Setup\UIAtoms2010\UIAtomsSuite\Debug\UIAtomsSuite.msi
