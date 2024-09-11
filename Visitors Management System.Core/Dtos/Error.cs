﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitors_Management_System.Core.Dtos
{
	public class Error
	{
		public static readonly IEnumerable<Error> None = Array.Empty<Error>();

		public Error(string code, string message)
		{
			Code = code;
			Message = message;
		}

		public string Message { get; }
		public string Code { get; }
	}
}
