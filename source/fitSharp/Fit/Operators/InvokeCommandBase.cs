﻿// Copyright © 2011 Syterra Software Inc. All rights reserved.
// The use and distribution terms for this software are covered by the Common Public License 1.0 (http://opensource.org/licenses/cpl.php)
// which can be found in the file license.txt at the root of this distribution. By using this software in any fashion, you are agreeing
// to be bound by the terms of this license. You must not remove this notice, or any other, from this software.

using fitSharp.Machine.Engine;
using fitSharp.Machine.Model;

namespace fitSharp.Fit.Operators {
    public abstract class InvokeCommandBase: CellOperator, InvokeOperator<Cell> {

        public abstract bool CanExecute(ExecuteContext context, ExecuteParameters parameters);
        public abstract TypedValue Execute(ExecuteContext context, ExecuteParameters parameters);

        public bool CanInvoke(TypedValue instance, string memberName, Tree<Cell> parameters) {
            return instance.Type == typeof(ExecuteContext) && CanExecute(instance.GetValue<ExecuteContext>(), new ExecuteParameters(parameters));
        }

        public TypedValue Invoke(TypedValue instance, string memberName, Tree<Cell> parameters) {
            return Execute(instance.GetValue<ExecuteContext>(), new ExecuteParameters(parameters));
        }
    }
}