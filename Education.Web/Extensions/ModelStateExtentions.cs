using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Web
{
    public static class ModelStateExtentions
    {
        /// <summary>
        /// 获取第一个错误信息
        /// </summary>
        /// <param name="modelState"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string FirstError(this ModelStateDictionary modelState)
        {
            if (modelState.IsValid == false)
            {
                //获取所有错误的Key
                List<string> keys = modelState.Keys.ToList();
                //获取每一个key对应的ModelStateDictionary
                foreach (var keyValue in keys)
                {
                    var errors = modelState[keyValue].Errors.ToList();
                    if (errors.Count > 0)
                    {
                        foreach (var error in errors)
                        {
                            if (string.IsNullOrWhiteSpace(error.ErrorMessage) == false)
                            {
                               return error.ErrorMessage; 

                            }
                        }
                    }
                }
            }
            return string.Empty;
        }
    }
}