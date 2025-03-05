var builder = DistributedApplication.CreateBuilder(args);
builder.AddProject<Projects.OpenISP>("openisp");
builder.Build().Run();
