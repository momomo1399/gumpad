/*
 * Copyright � 2007-2009, Pradyumna Kumar Revur.
 * All rights reserved.
 * 
 * 
 * GumPad is freeware. You may use it at your own risk for any purpose you like, subject to the following terms.
 * 
 * Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
 * 
 * * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
 * * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
 * * Neither the name of the the authors or copyright holders nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GumPad
{
    public partial class FormEncoding : Form
    {
        public FormEncoding()
        {
            InitializeComponent();
        }

        public Encoding SelectedEncoding {
            get
            {
                return selectedEncoding;
            }
        }

        private string [] encodingNames;
        private Encoding selectedEncoding = Encoding.Default;
        private Dictionary<string, Encoding> encMap = new Dictionary<string, Encoding>();

        private void FormEncoding_Load(object sender, EventArgs e)
        {
            if (encodingNames == null)
            {
                foreach (EncodingInfo enc in Encoding.GetEncodings())
                {
                    try
                    {
                        encMap.Add(enc.DisplayName + " (" + enc.Name + ")", enc.GetEncoding());
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                encodingNames = new string[encMap.Count];
                encMap.Keys.CopyTo(encodingNames, 0);
                cmbEncoding.Items.AddRange(encodingNames);
            }
        }

        private void cmbEncoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedEncoding = encMap[encodingNames[cmbEncoding.SelectedIndex]];
            }
            catch (Exception)
            {
                selectedEncoding = Encoding.Default;
            }
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}