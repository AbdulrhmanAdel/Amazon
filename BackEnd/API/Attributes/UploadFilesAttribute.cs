using System.Collections.Immutable;
using System.Security.Cryptography.X509Certificates;
using Core.Entities.Products;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace api.Attributes;

public class UploadFilesAttribute : ActionFilterAttribute
{
    private readonly string _path;

    public UploadFilesAttribute(string folderName = "files")
    {
        _path = Directory.GetCurrentDirectory() + "/wwwroot/" + folderName;
        Directory.CreateDirectory(_path);
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.HttpContext.Request.HasFormContentType)
        {
            await base.OnActionExecutionAsync(context, next);
            return;
        }

        var files = context.HttpContext.Request.Form.Files;
        
        var index = 0;
        IEnumerable<KeyValuePair<string, StringValues>> form = context.HttpContext.Request.Form;
        foreach (var formFile in files)
        {
            var id = Guid.NewGuid();
            var url = $"{_path}/{id}-{formFile.FileName}";

            await using var stream = File.Create(url);
            await formFile.CopyToAsync(stream);
            form = form
                // .Append(new KeyValuePair<string, StringValues>($"media[{index}].id", id.ToString()))
                .Append(new KeyValuePair<string, StringValues>($"media[{index}].url", url));
            // .Append(new KeyValuePair<string, StringValues>($"media[{index}].id", id.ToString()));
            index++;
        }

        context.HttpContext.Request.Form = new FormCollection(form
            .ToDictionary(x => x.Key, 
                x => x.Value));
        
        await base.OnActionExecutionAsync(context, next);
    }
}