using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace L_MP3_Boolean
{
    public class Model : Interface1
    {
        public List<Implementacao> Dados { get; set; }

        public event MetodosSemParametros SalaReservada;
        public event MetodosSemParametros leituraTerminada;

        public string Maximo { get; set; }

        public Model()
        {
            Dados = new List<Implementacao>();
        }

        public void EscritaXML(string ficheiro)
        {
            XDocument doc = new XDocument(new XDeclaration("1.0", Encoding.UTF8.ToString(), "yes"),
                                         new XElement("LojaLivro", new XElement("Vendido"), new XElement("NaoVendido")));

            foreach (Implementacao sal in Dados)
            {
                //Criar estrutura para as salas
                XElement novo = new XElement("book", new XAttribute("categoria", sal.Categoria),
                                                       new XElement("titulo", sal.Titulo),
                                                      new XElement("autor", sal.Autor));
                                                    

                if (sal.Vendido == true)
                    doc.Element("LojaLivro").Element("Vendido").Add(novo);
                else
                    doc.Element("LojaLivro").Element("NaoVendido").Add(novo);
            }

            doc.Save(ficheiro);
        }

        public void LeituraXML(string ficheiro)
        {
            Dados.Clear();
            XDocument doc = XDocument.Load(ficheiro);

            //Salas Ocupadas
            var Registo = from al in doc.Element("LojaLivro").Element("Vendido").Descendants("book")
                          select al;

            foreach (var campo in Registo)
            {
                //Criar objeto com os alunos respetivos
                Implementacao newSala = new Implementacao(campo.Attribute("categoria").Value, campo.Element("titulo").Value,
                    campo.Element("autor").Value);


                newSala.Vendido = true;

                //Adicionar à estrutura
                Dados.Add(newSala);
            }

            Registo = from al in doc.Element("LojaLivro").Element("NaoVendido").Descendants("book")
                      select al;

            foreach (var campo in Registo)
            {
                //Criar objeto com os alunos respetivos
                Implementacao newSala = new Implementacao(campo.Attribute("category").Value, campo.Element("titulo").Value,
                    campo.Element("autor").Value);


                newSala.Vendido = false;

                //Adicionar à estrutura
                Dados.Add(newSala);
            }

           // Lançamento do evento
            if (leituraTerminada != null)
                leituraTerminada();
        }

        public void ProcurarMaior(string titulo)
        {

            var list = (from pro in Dados
                        where pro.Titulo == titulo
                        orderby pro.Autor descending
                        select pro.Titulo).FirstOrDefault();

            if (list != null)
            {
                Maximo = list;
                leituraTerminada();
            }

            else
            {
                throw new OperaçaoInvalidaException("Erro!");
            }

        }

    }
    }

