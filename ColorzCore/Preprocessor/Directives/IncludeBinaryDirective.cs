﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorzCore.DataTypes;
using ColorzCore.Lexer;
using ColorzCore.Parser.AST;
using System.IO;
using ColorzCore.Parser;

namespace ColorzCore.Preprocessor.Directives
{
    class IncludeBinaryDirective : IDirective
    {
        public int MinParams { get { return 1; } }

        public int? MaxParams { get { return 1; } }

        public bool RequireInclusion { get { return true; } }

        public Maybe<ILineNode> Execute(EAParser p, Token self, IList<IParamNode> parameters, MergeableGenerator<Token> tokens)
        {
            Maybe<string> existantFile = IO.IOUtility.FindFile(self.FileName, parameters[0].ToString());
            if(!existantFile.IsNothing)
            {
                try
                {
                    string pathname = existantFile.FromJust;

                    return new Just<ILineNode>(new DataNode(File.ReadAllBytes(pathname)));
                }
                catch (Exception)
                {
                    p.Error(self.Location, "Error reading file \"" + parameters[0].ToString() + "\".");
                }
            }
            else
            {
                p.Error(parameters[0].MyLocation, "Could not find file \"" + parameters[0].ToString() + "\".");
            }
            return new Nothing<ILineNode>();
        }
    }
}