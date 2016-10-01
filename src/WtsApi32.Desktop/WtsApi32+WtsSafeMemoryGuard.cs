﻿// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <content>
    /// Exported functions from the WtsApi32.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    public static partial class WtsApi32
    {
        /// <summary>
        /// Base guard for all memory allocated inside WtsApi32.
        /// </summary>
        public partial class WtsSafeMemoryGuard : SafeHandle
        {
            public WtsSafeMemoryGuard()
                : base(IntPtr.Zero, false)
            {
            }

            public WtsSafeMemoryGuard(IntPtr invalidHandleValue, bool ownsHandle)
                : base(invalidHandleValue, ownsHandle)
            {
            }

            public override bool IsInvalid
            {
                get
                {
                    return this.handle == IntPtr.Zero;
                }
            }

            protected override bool ReleaseHandle()
            {
                WTSFreeMemory(this.handle);
                return true;
            }
        }
    }
}
