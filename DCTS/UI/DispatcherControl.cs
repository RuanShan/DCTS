﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCTS.UI
{
    public partial class DispatcherControl : UserControl
    {
        public delegate void RequestHandler(object sender, EventArgs e);

        public DispatcherControl()
        {
            InitializeComponent();
        }
    }
}
