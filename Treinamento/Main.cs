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
            // CONFIGURA A SELEÇÃO
            PromptPointOptions Opts = new PromptPointOptions("\nEspecifique o ponto no desenho");
            // SOLICITA A SELEÇÃO DE UM PONTO NO DESENHO
            PromptPointResult PontoClicado = DocEditor.GetPoint(Opts);
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

            PromptDoubleOptions Opts = new PromptDoubleOptions("\nEspecifique o comprimento");
            Opts.DefaultValue = 10;
            PromptDoubleResult NumeroDigitado = DocEditor.GetDouble(Opts);
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

            PromptStringOptions Opts = new PromptStringOptions("\nEspecifique o texto");
            Opts.AllowSpaces = true;
            PromptResult TextoDigitado = DocEditor.GetString(Opts);
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

            PromptIntegerOptions Opts = new PromptIntegerOptions("\nEspecifique o número inteiro");
            Opts.DefaultValue = 2;
         
            PromptIntegerResult NumeroDigitado = DocEditor.GetInteger(Opts);
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

            PromptEntityOptions Opts = new PromptEntityOptions("\nSelecione a polyline");
            Opts.SetRejectMessage("\nSelecione apenas polylines");
            Opts.AddAllowedClass(typeof(Polyline), true);
            PromptEntityResult ResultadoSel = DocEditor.GetEntity(Opts);
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

            PromptPointResult PontoClicado = DocEditor.GetPoint("\nEspecifique o ponto inicial");
            if (PontoClicado.Status == PromptStatus.OK)
            {
                PromptCornerOptions Opts = new PromptCornerOptions("\nEspecifique o segundo ponto", PontoClicado.Value);
                Opts.UseDashedLine = true;
                PromptPointResult PontoCorner = DocEditor.GetCorner(Opts);
                if (PontoCorner.Status == PromptStatus.OK)
                {
                    Point3d Ponto1 = PontoClicado.Value;
                    Point3d Ponto2 = PontoCorner.Value;
                   MessageBox.Show("Primeira Coordenada: " + Ponto1.X.ToString() + ", " + Ponto1.Y.ToString());
                    MessageBox.Show("Segunda Coordenada: " + Ponto2.X.ToString() + ", " + Ponto2.Y.ToString());
                }
            }
        }
        [CommandMethod("SELECIONACIRCULOS")]
        public void SELECIONACIRCULOS()
        {
            // RECEBE AS PRINCIPAIS VARIÁVEIS DA AUTODESK
            Document DocCAD = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database DocData = DocCAD.Database;
            Editor DocEditor = DocCAD.Editor;
            TypedValue TipoCirculo = new TypedValue(0, "CIRCLE");
            SelectionFilter SelFiltro = new SelectionFilter(new TypedValue[] { TipoCirculo });
            PromptSelectionOptions Opts = new PromptSelectionOptions();
            Opts.MessageForAdding = "\nSelecione os círculos";
            Opts.MessageForRemoval = "\nApenas círculos";
            PromptSelectionResult SelObjetos = DocEditor.GetSelection(Opts, SelFiltro);
            if (SelObjetos.Status == PromptStatus.OK)
            {
                MessageBox.Show("A quantidade de objetos selecionados foi: " + SelObjetos.Value.Count.ToString());
            }   
        }

    }
}
