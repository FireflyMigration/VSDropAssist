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