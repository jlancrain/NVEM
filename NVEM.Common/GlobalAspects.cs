using NVEM.PostSharp;

//These entries setup the configuration for postsharp to include this project for logging purposes
[assembly: LogException(AttributeTargetTypes = "NVEM.Common.*", AspectPriority = 1)]
[assembly: LogTrace(AttributeTargetTypes = "NVEM.Common.*", AttributeExclude = true, AttributeTargetMembers = "regex:get_.*|set_.*")]
[assembly: LogTrace(AttributeTargetTypes = "NVEM.Common.*", AspectPriority = 2)]