using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public enum OperationResult
    {
        /// <summary>
        /// 记录已存在
        /// </summary>
        exist,
        /// <summary>
        /// 成功
        /// </summary>
        success,
        /// <summary>
        /// 失败
        /// </summary>
        failure
    }

    public enum DeletResult
    {
        /// <summary>
        /// 记录不存在
        /// </summary>
        noExist,
        /// <summary>
        /// 成功
        /// </summary>
        success,
        /// <summary>
        /// 失败
        /// </summary>
        failure
    }
}
