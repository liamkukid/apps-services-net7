using BenchmarkDotNet.Running;
using Ch02Ex02_ADONETvsEFCore;


//var t = new DBAccessBenchmarks().ADOTest();
BenchmarkRunner.Run<DBAccessBenchmarks>();
