
using System;

namespace EVisa100.Enums
{
    public enum TransportationBy
    {
        Air = 0,
        Road,
        Ship
    }

    public enum Purpose
    {
        Tourism = 0,
        Business,
        Education,
        Employment,
        Medical,
        Religion,
        Settlement,
        Others
    }

    public enum MaritalStatus
    {
        Single,
        Married,
        Widowed,
        Divorced,
        Separated
    }

    public enum JobType
    {
        Student = 0,
        Unemployed,
        Employed,
        Retired,
        Others
    }

    [Flags]
    public enum ApplicationStatus
    {
        None = 0,
        Created = 1,
        Paid = 2,
        Reviewed = 4,
        Submitted = 8,
        Succeeded = 16,
        Failed = 32
    }
}