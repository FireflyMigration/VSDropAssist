# VSDropAssist

VSDropAssist generates custom code from dropped class members

# Usage
Drag one or more objects from the Solution Explorer and drop onto a code window.

Drop whilst holding down the following buttons to generate different text:


## if dragging 1-or-more class members
(use ctrl or shift-click to select multiple items in the solution explorer)


| Key   | Pasted Value            |
| ----- | ----------------------- |
| ALT   | %v%.%m%.Value = ;\n     |
| SHIFT | Columns.Add(%v%.%m%);\n |
| none  | %v%.%m%,\n              |


## If dragging at least 1 class
(use ctrl or shift-click to select multiple items in the solution explorer)

| Key   | Pasted Value                                                            |
| ----- | ----------------------------------------------------------------------- |
| none  | %f%\n                                                                   |
| shift | If dropping into a method:			var %v% = new %f%();\n                     |
| shift | if dropping outside of a method:	public readonly %f% %v% = new %f%();\n |


#### NOTE:
* %v%	=	Type name
* %m% =	Method/member name


After dropping, the %v% is selected and you can immediately type a new name (press ESC to cancel the selection)

# Setup
* Install VS2019 and VS2022 (depending on the project)
* Install VSX extension
* Open the sln in either 2022 or 2017 folder


