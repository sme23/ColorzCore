﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorzCore.Lexer;

namespace ColorzCore.Parser.AST
{
    class EAProgram : IASTNode
    {
        public ASTNodeType Type => ASTNodeType.EAPROGRAM;

        public string File { get; private set; }
        public int Line { get; private set; }
        public int Column { get; private set; }

        public Token startToken => throw new NotImplementedException();
    }
}