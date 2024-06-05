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
    }
}
