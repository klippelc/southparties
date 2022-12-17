using Common;
using MediatR;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Application.BaseObjects
{
    public class KernelControllerBase : Controller
    {
        protected IMediator MediatR { get; set; }
        protected string SystemAccount => "10000000-1000-1000-10000000000000000";
        protected string TenantId => AppConstants.TenantId;
        protected string EIMSClientId => AppConstants.EIMSClientId;
        protected string EIMSClientSecret => AppConstants.EIMSClientSecret;
        protected string ApplicationName => AppConstants.ApplicationName;
        protected string ADApplicationName => AppConstants.AdApplicationName;

        // TODO: 14. Not sure what this is used for?
        //protected ActionResult RedirectToAction<TController>(Expression<Action<TController>> action)
        //    where TController : Controller => ControllerExtensions.RedirectToAction(this, action);

        [Obsolete("Do not use the standard Json helpers to return JSON data to the client.  Use either JsonSuccess or JsonError instead.")]
        protected JsonResult Json<T>(T data) => throw new InvalidOperationException("Do not use the standard Json helpers to return JSON data to the client.  Use either JsonSuccess or JsonError instead.");

        // TODO: 15. Not sure what this is used for?
        //protected KernelStandardJsonResult JsonValidationError()
        //{
        //    var result = new KernelStandardJsonResult();

        //    foreach (var validationError in ModelState.Values.SelectMany(v => v.Errors))
        //    {
        //        result.AddError(validationError.ErrorMessage);
        //    }
        //    return result;
        //}

        // TODO: 15. Not sure what this is used for?
        //protected KernelStandardJsonResult JsonError(string errorMessage)
        //{
        //    var result = new KernelStandardJsonResult();

        //    result.AddError(errorMessage);

        //    return result;
        //}

        // TODO: 16. Not sure what this is used for?
        //protected KernelStandardJsonResult<T> JsonSuccess<T>(T data) => new KernelStandardJsonResult<T> { Data = data };
    }
}
