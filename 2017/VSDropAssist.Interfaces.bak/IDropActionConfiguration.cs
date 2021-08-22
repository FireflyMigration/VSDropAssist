namespace VSDropAssist
{
    public interface IDropActionConfiguration
    {
        bool ShiftMustBeDown { get;  }
        bool ControlMustBeDown { get;  }
        bool AltMustBeDown { get;  }
        string FormatExpression { get;  }
        bool SelectAfterDrop { get;  }
        bool SupportsMembers { get;  }
        bool SupportsClasses { get;  }
        string Delimiter { get; }
        bool SupportsDroppingIntoMethod { get;  }
        bool SupportsDroppingIntoClass { get;  }
        string TokenToSelectAfterDrop { get; }
        bool SelectFirstLineOnly { get;  }

        string ToString(bool showKeys = true, bool showDragItems = true, bool showDropTarget = true);
        
    }
}