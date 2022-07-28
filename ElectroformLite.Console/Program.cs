using ElectroformLite.Domain.Models;
using ElectroformLite.Domain.Services;

List<Data> dataList = DataService.GetData();
List<DataGroup> dataGroups = DataGroupService.GetDataGroups();

List<Template> templates = TemplateService.GetTemplates();
List<Document> documents = DocumentService.GetDocuments();

List<int> dataGroupIndices = new() { 0, 1 };
List<int> documentIndices = new() { 0 };


User user = UserService.GetUser("John Doh", dataGroupIndices, documentIndices);
Console.WriteLine($"Hello, {user.Name}!");
