using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESORuleEngine
{
    public enum ODataMetadataType
    {
        /// <summary>
        /// odata.metadata=minimal
        /// </summary>
        MinOnly,

        /// <summary>
        /// odata.metadata=full
        /// </summary>
        FullOnly,

        /// <summary>
        /// odata.metadata=none
        /// </summary>
        None
    }
    public enum ConformanceDependencyType
    {
        /// <summary>
        /// The single rule.
        /// </summary>
        Single = 0,

        /// <summary>
        /// The dependency rule.
        /// </summary>
        Dependency = 1,

        /// <summary>
        /// The conformance rule is skipped.
        /// </summary>
        Skip = 2,
    }

    /// <summary>
    /// Enum service type of conformance level rules.
    /// </summary>
    public enum ConformanceServiceType
    {
        /// <summary>
        /// The ReadWrite resource.
        /// </summary>
        ReadWrite = 0,

        /// <summary>
        /// The ReadOnly resource.
        /// </summary>
        ReadOnly = 1,
    }

    /// <summary>
    /// Enum level type of conformance level rules.
    /// </summary>
    public enum ConformanceLevelType
    {
        /// <summary>
        /// The Minimal level.
        /// </summary>
        Minimal = 0,

        /// <summary>
        /// The Intermediate level.
        /// </summary>
        Intermediate = 1,

        /// <summary>
        /// The Advanced level
        /// </summary>
        Advanced = 2,
    }

    /// <summary>
    /// Enum check type of checking dependent rules.
    /// </summary>
    public enum ConformanceCheckType
    {
        /// <summary>
        /// All binding rules need to be passed.
        /// </summary>
        AllPass,

        /// <summary>
        /// Check all minimal rules' result.
        /// </summary>
        AllMinimal,

        /// <summary>
        /// Check all Intermediate rules' result.
        /// </summary>
        AllIntermediate
    }

    /// <summary>
    /// The relationship of main rule and dependent rules.
    /// </summary>
    public enum ConformanceRuleRelationship
    {
        /// <summary>
        /// No relationship of the rule.
        /// </summary>
        None,

        /// <summary>
        /// The dependent rules are sub rules of main rule.
        /// </summary>
        SubRule,

        /// <summary>
        /// The dependent rules are derived rules of main rules.
        /// </summary>
        DerivedRule,
    }
    public enum ODataVersion
    {
        /// <summary>
        /// unknown version
        /// </summary>
        UNKNOWN = 0,

        /// <summary>
        /// version 1.0 or version 2.0
        /// </summary>
        V1_V2 = -1,

        /// <summary>
        /// any OData version
        /// </summary>
        V_All = -2,

        /// <summary>
        /// veriosn 1.0
        /// </summary>
        V1 = 1,

        /// <summary>
        /// version 2.0
        /// </summary>
        V2 = 2,

        /// <summary>
        /// version 3.0
        /// </summary>
        V3 = 3,

        /// <summary>
        /// version 4.0
        /// </summary>
        V4 = 4,

        /// <summary>
        /// version 3.0 or version 4.0
        /// </summary>
        V3_V4 = 5,

        /// <summary>
        /// version 1.0 or 2.0 or 3.0
        /// </summary>
        V1_V2_V3 = 6,
    }
    public enum PayloadFormat
    {
        /// <summary>
        /// No payload format.
        /// </summary>
        None = 0,

        /// <summary>
        /// Payload is of atompub format.
        /// </summary>
        Atom,

        /// <summary>
        /// Payload is of json verbose format.
        /// </summary>
        Json,

        /// <summary>
        /// Payload is json light format.
        /// </summary>
        JsonLight,

        /// <summary>
        /// Payload is of general xml format.
        /// </summary>
        Xml,

        /// <summary>
        /// Image format.
        /// </summary>
        Image,

        /// <summary>
        /// Other format.
        /// </summary>
        Other,
    }
    public enum PayloadType
    {
        /// <summary>
        /// No payload type.
        /// </summary>
        None = 0,

        /// <summary>
        /// Payload type of service document.
        /// </summary>
        ServiceDoc = 1,

        /// <summary>
        /// Payload type of metadata document.
        /// </summary>
        Metadata = 2,

        /// <summary>
        /// Payload type of feed (entity set).
        /// </summary>
        Feed = 3,

        /// <summary>
        /// Payload type of entry (entity).
        /// </summary>
        Entry = 4,

        /// <summary>
        /// Payload type of OData error message.
        /// </summary>
        Error = 5,

        /// <summary>
        /// Payload type of OData property (including complex type property and primitive property)
        /// </summary>
        Property = 6,

        /// <summary>
        /// Payload type of raw value
        /// </summary>
        RawValue = 7,

        /// <summary>
        /// Payload type of OData link
        /// </summary>
        Link = 8,

        /// <summary>
        /// Payload type of delta response
        /// </summary>
        Delta = 9,

        /// <summary>
        /// Payload type of entity reference
        /// </summary>
        EntityRef = 10,

        /// <summary>
        /// Payload type of Individual Property
        /// </summary>
        IndividualProperty = 11,

        /// <summary>
        /// Other payload irrelevant to OData.
        /// </summary>
        Other = 99,
    }
    public enum RequirementLevel
    {
        /// <summary>
        /// MUST-level rule
        /// </summary>
        Must = 0,

        /// <summary>
        /// SHOULD-level
        /// </summary>
        Should,

        /// <summary>
        /// RECOMMENDED-level
        /// </summary>
        Recommended,

        /// <summary>
        /// MAY-level
        /// </summary>
        May,

        /// <summary>
        /// MUST NOT level
        /// </summary>
        MustNot,

        /// <summary>
        /// SHOULD NOT level
        /// </summary>
        ShouldNot,
    }
}
