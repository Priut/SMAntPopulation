using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMProject
{
    public partial class Form1 : Form
    {
        private Graph graph = new Graph();
        public Form1()
        {
            InitializeComponent();

            graph.AddNode(5);
            graph.AddNode(3);
            graph.AddNode(0);
            graph.AddNode(0);
            graph.AddNode(0);
            graph.AddNode(7);
            graph.AddNode(0);
            graph.AddNode(0);
            graph.AddNode(0);
            graph.AddNode(0);
            graph.AddNode(0);
            graph.AddNode(0);

            var node1 = graph.Nodes[0];
            var node2 = graph.Nodes[1];
            var node3 = graph.Nodes[2];
            var node4 = graph.Nodes[3];
            var node5 = graph.Nodes[4];
            var node6 = graph.Nodes[5];
            var node7 = graph.Nodes[6];
            var node8 = graph.Nodes[7];
            var node9 = graph.Nodes[8];
            var node10 = graph.Nodes[9];
            var node11 = graph.Nodes[10];
            var node12 = graph.Nodes[11];


            node1.Position = new Point(50, 200);
            node2.Position = new Point(130, 100);
            node3.Position = new Point(170, 150);
            node4.Position = new Point(250, 120);
            node5.Position = new Point(320, 70);
            node6.Position = new Point(400, 120);
            node7.Position = new Point(470, 80);
            node8.Position = new Point(550, 20);
            node9.Position = new Point(620, 20);
            node10.Position = new Point(600, 80);
            node11.Position = new Point(550, 120);
            node12.Position = new Point(600, 200);

            node1.isHome = true;

            graph.AddEdge(node1, node2);
            graph.AddEdge(node1, node3);
            graph.AddEdge(node2, node3);
            graph.AddEdge(node2, node4);
            graph.AddEdge(node3, node4);
            graph.AddEdge(node3, node11);
            graph.AddEdge(node4, node5);
            graph.AddEdge(node4, node6);
            graph.AddEdge(node5, node6);
            graph.AddEdge(node5, node7);
            graph.AddEdge(node5, node8);
            graph.AddEdge(node6, node7);


            // Force the form to repaint
            Invalidate();

        }

        private void DrawGraph(Graphics g)
        {
            foreach (var edge in graph.Edges)
            {
                var node1 = edge.Key.Item1;
                var node2 = edge.Key.Item2;

                // Draw edge with weight thickness
                Pen pen = new Pen(Color.Black, (float)edge.Value);
                g.DrawLine(pen, GetNodePosition(node1), GetNodePosition(node2));
            }

            foreach (var node in graph.Nodes)
            {
                if(node.isHome)
                    g.FillEllipse(Brushes.Blue, GetNodeRectangle(node));
                else
                    g.FillEllipse(Brushes.Black, GetNodeRectangle(node));
            }
        }

        private Point GetNodePosition(Node node)
        {
            return node.Position;
        }

        private Rectangle GetNodeRectangle(Node node)
        {
            var position = GetNodePosition(node);
            return new Rectangle(position.X - 10, position.Y - 10, 20, 20);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); // Ensure the base painting logic runs
            DrawGraph(e.Graphics); // Call your custom drawing method
        }

    }
}

