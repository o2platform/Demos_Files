using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperSecureBank
{
	public class SessionIDSingleton
	{
		Int64 currentID = 0;
		static readonly SessionIDSingleton instance = new SessionIDSingleton();

		// Explicit static constructor to tell C# compiler
		// not to mark type as beforefieldinit
		static SessionIDSingleton()
		{
		}

		SessionIDSingleton()
		{
		}

		public static SessionIDSingleton Instance
		{
			get
			{
				return instance;
			}
		}

		public Int64 NextSessionID
		{
			get
			{
                currentID = new Random((int)currentID).Next(Int32.MaxValue);
                return currentID;
			}
		}
	}
}