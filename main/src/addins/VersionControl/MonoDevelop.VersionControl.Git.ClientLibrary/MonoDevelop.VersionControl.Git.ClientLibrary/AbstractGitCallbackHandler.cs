﻿//
// GitProcess.cs
//
// Author:
//       Mike Krüger <mikkrg@microsoft.com>
//
// Copyright (c) 2019 Microsoft Corporation. All rights reserved.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;

namespace MonoDevelop.VersionControl.Git.ClientLibrary
{
	public abstract class AbstractGitCallbackHandler
	{
		public static readonly AbstractGitCallbackHandler NullHandler = new DoNothingGitCallbackHandler ();

		public abstract void OnOutput (string line);
		public abstract void OnReportProgress (string operation, int percentage);

		public abstract GitCredentials OnGetCredentials (string url);

		public abstract string OnGetSSHPassword (string userName);
		public abstract string OnGetSSHPassphrase (string key);
		public abstract bool OnGetContinueConnecting ();

		class DoNothingGitCallbackHandler : AbstractGitCallbackHandler
		{
			public override bool OnGetContinueConnecting ()
			{
				return false;
			}

			public override GitCredentials OnGetCredentials (string url)
			{
				return null;
			}

			public override string OnGetSSHPassphrase (string key)
			{
				return null;
			}

			public override string OnGetSSHPassword (string userName)
			{
				return null;
			}

			public override void OnOutput (string line)
			{
			}

			public override void OnReportProgress (string operation, int percentage)
			{
			}
		}
	}
}