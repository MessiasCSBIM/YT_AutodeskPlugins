using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using System.Windows.Forms;

namespace Treinamento
{
    public class Main
    {
        [CommandMethod("PEGAPONTO")]
        public void PEGAPONTO()
        {
            // RECEBE AS PRINCIPAIS VARIÁVEIS DA AUTODESK
            Document DocCAD = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database DocData = DocCAD.Database;
            Editor DocEditor = DocCAD.Editor;
            // SOLICITA A SELEÇÃO DE UM PONTO NO DESENHO
            PromptPointResult PontoClicado = DocEditor.GetPoint("Especifique o ponto no desenho");
            // VERIFICA SE O USUÁRIO ESPECIFICOU UM PONTO NA TELA
            if (PontoClicado.Status == PromptStatus.OK)
            {
                DocEditor.WriteMessage(PontoClicado.Value.X.ToString() + " | " + PontoClicado.Value.Y.ToString());
            }
        }

        [CommandMethod("PEGANUMERO")]
        public void PEGANUMERO()
        {
            // RECEBE AS PRINCIPAIS VARIÁVEIS DA AUTODESK
            Document DocCAD = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database DocData = DocCAD.Database;
            Editor DocEditor = DocCAD.Editor;

            PromptDoubleResult NumeroDigitado = DocEditor.GetDouble("Especifique o comprimento");
            if (NumeroDigitado.Status == PromptStatus.OK)
            {
                MessageBox.Show("O valor digitado é : " + NumeroDigitado.Value.ToString());
            }
         
        }

        [CommandMethod("PEGATEXTO")]
        public void PEGATEXTO()
        {
            // RECEBE AS PRINCIPAIS VARIÁVEIS DA AUTODESK
            Document DocCAD = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database DocData = DocCAD.Database;
            Editor DocEditor = DocCAD.Editor;

            PromptResult TextoDigitado = DocEditor.GetString("Especifique o texto");
            if (TextoDigitado.Status == PromptStatus.OK)
            {
                MessageBox.Show("O texto digitado foi: " + TextoDigitado.StringResult);
            }
        }

        [CommandMethod("PEGANUMEROINTEIRO")]
        public void PEGANUMEROINTEIRO()
        {
            // RECEBE AS PRINCIPAIS VARIÁVEIS DA AUTODESK
            Document DocCAD = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database DocData = DocCAD.Database;
            Editor DocEditor = DocCAD.Editor;
            PromptIntegerResult NumeroDigitado = DocEditor.GetInteger("Especifique o número inteiro");
            if (NumeroDigitado.Status == PromptStatus.OK)
            {
                MessageBox.Show("O número digitado foi: " + NumeroDigitado.Value.ToString());
            }
        }

        [CommandMethod("PEGAENTIDADE")]
        public void PEGAENTIDADE()
        {
            // RECEBE AS PRINCIPAIS VARIÁVEIS DA AUTODESK
            Document DocCAD = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database DocData = DocCAD.Database;
            Editor DocEditor = DocCAD.Editor;

            PromptEntityResult ResultadoSel = DocEditor.GetEntity("Selecione o objeto");
            if (ResultadoSel.Status == PromptStatus.OK)
            {
                MessageBox.Show("O objeto foi selecionado");
            } else
            {
                MessageBox.Show("O objeto não foi selecionado");
            }
        }

        [CommandMethod("PEGACORNER")]
        public void PEGACORNER()
        {
            // RECEBE AS PRINCIPAIS VARIÁVEIS DA AUTODESK
            Document DocCAD = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database DocData = DocCAD.Database;
            Editor DocEditor = DocCAD.Editor;

            PromptPointResult PontoClicado = DocEditor.GetPoint("Especifique o ponto inicial");
            if (PontoClicado.Status == PromptStatus.OK)
            {
                PromptPointResult PontoCorner = DocEditor.GetCorner("Especifique o segundo ponto", PontoClicado.Value);
                if (PontoCorner.Status == PromptStatus.OK)
                {
                    Point3d Ponto1 = PontoClicado.Value;
                    Point3d Ponto2 = PontoCorner.Value;
                   MessageBox.Show("Primeira Coordenada: " + Ponto1.X.ToString() + ", " + Ponto1.Y.ToString());
                    MessageBox.Show("Segunda Coordenada: " + Ponto2.X.ToString() + ", " + Ponto2.Y.ToString());
                }
            }
        }

    }
}
