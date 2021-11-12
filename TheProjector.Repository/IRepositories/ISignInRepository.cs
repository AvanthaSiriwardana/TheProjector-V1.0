﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheProjector.Domain.Entities;

namespace TheProjector.Repository
{
	public interface ISignInRepository
	{
		Person GetUser(string email, string password);
	}
}
