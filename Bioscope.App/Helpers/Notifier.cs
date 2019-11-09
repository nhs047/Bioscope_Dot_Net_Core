using Microsoft.AspNetCore.Mvc;

namespace Bioscope.App.Helpers
{
    public static class Notifier
    {
        public static string Message { get; set; } = "null";
        public static void Remove() => Message = "null";

        public static RedirectToActionResult NotifySaved(this RedirectToActionResult result)
        {
            Message = Noty.Added;
            return result;
        }
        public static RedirectToActionResult NotifyUpdated(this RedirectToActionResult result)
        {
            Message = Noty.Updated;
            return result;
        }
        public static RedirectToActionResult NotifyDeleted(this RedirectToActionResult result)
        {
            Message = Noty.Deleted;
            return result;
        }
        public static RedirectToActionResult NotifySuccess(this RedirectToActionResult result, string message)
        {
            Message = Noty.Success(message);
            return result;
        }
        public static RedirectToActionResult NotifyError(this RedirectToActionResult result, string message)
        {
            Message = Noty.Error(message);
            return result;
        }
        public static RedirectToActionResult NotifyError(this RedirectToActionResult result, string message, string title)
        {
            Message = Noty.Error(message, title);
            return result;
        }
        public static RedirectToActionResult NotifyServerError(this RedirectToActionResult result)
        {
            Message = Noty.ServerError;
            return result;
        }
        public static RedirectToActionResult NotifyBadRequest(this RedirectToActionResult result)
        {
            Message = Noty.BadRequest;
            return result;
        }
        public static RedirectToActionResult NotifyValidationError(this RedirectToActionResult result)
        {
            Message = Noty.ValidationError;
            return result;
        }
        public static RedirectToActionResult NotifyHttpNotFound(this RedirectToActionResult result)
        {
            Message = Noty.HttpNotFound;
            return result;
        }
        public static RedirectToActionResult NotifyNoRecordFound(this RedirectToActionResult result)
        {
            Message = Noty.NoRecordFound;
            return result;
        }

        public static ViewResult NotifySaved(this ViewResult result)
        {
            Message = Noty.Added;
            return result;
        }
        public static ViewResult NotifyUpdated(this ViewResult result)
        {
            Message = Noty.Updated;
            return result;
        }
        public static ViewResult NotifyDeleted(this ViewResult result)
        {
            Message = Noty.Deleted;
            return result;
        }
        public static ViewResult NotifySuccess(this ViewResult result, string message)
        {
            Message = Noty.Success(message);
            return result;
        }
        public static ViewResult NotifyError(this ViewResult result, string message)
        {
            Message = Noty.Error(message);
            return result;
        }
        public static ViewResult NotifyError(this ViewResult result, string message, string title)
        {
            Message = Noty.Error(message, title);
            return result;
        }
        public static ViewResult NotifyServerError(this ViewResult result)
        {
            Message = Noty.ServerError;
            return result;
        }
        public static ViewResult NotifyBadRequest(this ViewResult result)
        {
            Message = Noty.BadRequest;
            return result;
        }
        public static ViewResult NotifyValidationError(this ViewResult result)
        {
            Message = Noty.ValidationError;
            return result;
        }
        public static ViewResult NotifyHttpNotFound(this ViewResult result)
        {
            Message = Noty.ValidationError;
            return result;
        }
        public static ViewResult NotifyNoRecordFound(this ViewResult result)
        {
            Message = Noty.NoRecordFound;
            return result;
        }

        public static RedirectResult NotifySaved(this RedirectResult result)
        {
            Message = Noty.Added;
            return result;
        }
        public static RedirectResult NotifyUpdated(this RedirectResult result)
        {
            Message = Noty.Updated;
            return result;
        }
        public static RedirectResult NotifyDeleted(this RedirectResult result)
        {
            Message = Noty.Deleted;
            return result;
        }
        public static RedirectResult NotifySuccess(this RedirectResult result, string message)
        {
            Message = Noty.Success(message);
            return result;
        }
        public static RedirectResult NotifyError(this RedirectResult result, string message)
        {
            Message = Noty.Error(message);
            return result;
        }
        public static RedirectResult NotifyError(this RedirectResult result, string message, string title)
        {
            Message = Noty.Error(message, title);
            return result;
        }
        public static RedirectResult NotifyServerError(this RedirectResult result)
        {
            Message = Noty.ServerError;
            return result;
        }
        public static RedirectResult NotifyBadRequest(this RedirectResult result)
        {
            Message = Noty.BadRequest;
            return result;
        }
        public static RedirectResult NotifyValidationError(this RedirectResult result)
        {
            Message = Noty.ValidationError;
            return result;
        }
        public static RedirectResult NotifyHttpNotFound(this RedirectResult result)
        {
            Message = Noty.ValidationError;
            return result;
        }
        public static RedirectResult NotifyNoRecordFound(this RedirectResult result)
        {
            Message = Noty.NoRecordFound;
            return result;
        }

        public static void NotifySaved() => Message = Noty.Added;
        public static void NotifyUpdated() => Message = Noty.Updated;
        public static void NotifyDeleted() => Message = Noty.Deleted;
        public static void NotifySuccess(string message) => Message = Noty.Success(message);
        public static void NotifyError(string message) => Message = Noty.Error(message);
        public static void NotifyError(string message, string title) => Message = Noty.Error(message, title);
        public static void NotifyServerError() => Message = Noty.ServerError;
        public static void NotifyBadRequest() => Message = Noty.BadRequest;
        public static void NotifyValidationError() => Message = Noty.ValidationError;
        public static void NotifyHttpNotFound() => Message = Noty.ValidationError;
        public static void NotifyNoRecordFound() => Message = Noty.NoRecordFound;
    }
}
