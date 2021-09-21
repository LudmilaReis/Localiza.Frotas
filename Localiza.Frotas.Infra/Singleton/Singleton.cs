﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.Frotas.Infra.Singleton
{
    public sealed class Singleton
    {
        //toda vez que ele inicializar essa classe ele vai receber um id 
        public Guid Id { get; } = Guid.NewGuid();

        private static Singleton instance = null;

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

    }
}
