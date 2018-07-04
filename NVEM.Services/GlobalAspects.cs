using NVEM.PostSharp;

//These entries setup the configuration for postsharp to include this project for logging purposes
[assembly: LogException(AttributeTargetTypes = "NVEM.Services.*", AspectPriority = 1)]
[assembly: LogTrace(AttributeTargetTypes = "NVEM.Services.*", AttributeExclude = true, AttributeTargetMembers = "regex:get_.*|set_.*")]
[assembly: LogTrace(AttributeTargetTypes = "NVEM.Services.*", AspectPriority = 2)]
