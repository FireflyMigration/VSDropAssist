namespace VSDropAssist.Settings
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
        string Prefix { get; set; }
        string Suffix { get; set; }
        IDropActionConfiguration Clone();
        void CopyFrom(IDropActionConfiguration src);
    }
}