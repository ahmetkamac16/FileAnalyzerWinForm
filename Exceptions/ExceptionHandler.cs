using System;
using System.Threading.Tasks;

namespace FileAnalyzerWinForm.Exceptions
{
    public static class ExceptionHandler
    {
        public static async Task<T> ExecuteAsync<T>(
            Func<Task<T>> action,
            Func<Exception, T> onError,
            Func<Exception, bool> canHandle = null)
        {
            try
            {
                return await action();
            }
            catch (Exception ex) when (canHandle == null || canHandle(ex))
            {
                return onError(ex);
            }
        }

        public static T Execute<T>(
            Func<T> action,
            Func<Exception, T> onError,
            Func<Exception, bool> canHandle = null)
        {
            return ExecuteAsync(() => Task.FromResult(action()), onError, canHandle)
                .GetAwaiter()
                .GetResult();
        }
    }
}