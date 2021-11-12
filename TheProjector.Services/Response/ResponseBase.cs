using System;
using System.Collections.Generic;
using System.Text;

namespace TheProjector.Services
{
	public class ResponseBase
	{
		public string ResponseCode { get; set; }

		public string ResponseDescription { get; set; }
	}

	public class Response<T> : ResponseBase
	{
		public T Result { get; set; }
		}
	}
