using ChurchSchool.Service.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ChurchSchool.Service.Implementations
{
    public class ViewRenderService : IViewRenderService
    {
        private readonly IRazorViewEngine _viewEngine;
        private readonly ITempDataProvider _tempDataProvider;
        private readonly IServiceProvider _serviceProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ViewRenderService(IRazorViewEngine viewEngine,
                                 ITempDataProvider tempDataProvider,
                                 IServiceProvider serviceProvider,
                                 IHttpContextAccessor httpContextAccessor)
        {
            _viewEngine = viewEngine;
            _tempDataProvider = tempDataProvider;
            _serviceProvider = serviceProvider;
            _httpContextAccessor = httpContextAccessor;           
        }


        public async Task<string> RenderToStringAsync(string viewName)
        {
            return await RenderToStringAsync<string>(viewName, string.Empty);
        }

        public async Task<string> RenderToStringAsync<TModel>(string viewName, TModel model)
        {
            try
            {
                var httpContext = _httpContextAccessor.HttpContext ?? new DefaultHttpContext { RequestServices = _serviceProvider };

                var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

                using (var writer = new StringWriter())
                {
                    var viewResult = _viewEngine.FindView(actionContext, viewName, false);

                    if (viewResult.View == null)
                    {
                        viewResult = _viewEngine.GetView("~/", viewName, false);
                    }

                    if (viewResult.View == null)
                    {
                        throw new ArgumentNullException($"A {viewName} não existe");
                    }

                    var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                    {
                        Model = model
                    };

                    var viewContext = new ViewContext(
                        actionContext,
                        viewResult.View,
                        viewDictionary,
                        new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
                        writer,
                        new HtmlHelperOptions()
                    );

                    await viewResult.View.RenderAsync(viewContext);
                    return writer.ToString();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
