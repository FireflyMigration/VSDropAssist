# VSDropAssist
VSDropAssist generates custom code from dropped class members

Usage:
Drag one or more objects from the Solution Explorer and drop onto a code window.

Drop whilst holding down the following buttons to generate different text:


If dragging 1-or-more class members (use ctrl or shift-click to select multiple items in the solution explorer)
	ALT		%v%.%m%.Value = ;\n
	SHIFT	Columns.Add(%v%.%m%);\n
	none	%v%.%m%,\n

If dragging at least 1 class (use ctrl or shift-click to select multiple items in the solution explorer)

	none	 %f%\n
	shift	If dropping into a method:			var %v% = new %f%();\n
			if dropping outside of a method:	public readonly %f% %v% = new %f%();\n

Where
%v%	=	Type name
%m% =	Method/member name

After dropping, the %v% is selected and you can immediately type a new name (press ESC to cancel the selection)

# Development
Often you need to force a reinstall of the nuget packages (unsure why)
1. Launch VS
2. Launch Package Manager Console
3. run `update-package -reinstall`
4. you may need to `set-executionpolicy remotesigned`

# Debugging
1. Set startup project to VSDropAssist.2017
2. Set Project options to Start External Program, point to your vs2017 devenv 
common examples:
`C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe`
`C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\devenv.exe`

3. set command line args to `/rootsuffix Exp`
4. F5 to start debugging
