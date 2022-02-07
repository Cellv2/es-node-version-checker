// See https://aka.ms/new-console-template for more information
using Elasticsearch.Net;
using Nest;

var settings = new ConnectionConfiguration(new Uri("http://localhost:9200"))
    .RequestTimeout(TimeSpan.FromMinutes(2));

var lowlevelClient = new ElasticLowLevelClient(settings);

NodesInfoResponse nodesInfoResult = await lowlevelClient.Nodes.InfoForAllAsync<NodesInfoResponse>();
var nodeList = nodesInfoResult.Nodes.ToList();

Console.WriteLine(nodesInfoResult.ClusterName);
nodeList.ForEach(node =>
{
    //Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"{node.Value.Name} - {node.Value.Version}");
});
Console.WriteLine("");