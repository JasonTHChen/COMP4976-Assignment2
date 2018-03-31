using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lmyc.ViewModels
{
	public class LogoutViewModel
	{
		[BindNever]
		public string RequestId { get; set; }
	}
}
