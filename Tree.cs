using System;
using System.Collections.Generic;
using System.Text;

namespace _3Lxj
{
    public class BoTree<String>
    {
        public BoTree()
        {
            nodes = new List<BoTree<String>>();
        }

        public BoTree(String data)
        {
            this.Data = data;
            nodes = new List<BoTree<String>>();
        }

        private BoTree<String> parent;
        /// <summary>
        /// 父结点
        /// </summary>
        public BoTree<String> Parent
        {
            get { return parent; }
        }
        /// <summary>
        /// 结点数据
        /// </summary>
        public String Data { get; set; }

        private List<BoTree<String>> nodes;
        /// <summary>
        /// 子结点
        /// </summary>
        public List<BoTree<String>> Nodes
        {
            get { return nodes; }
        }
        /// <summary>
        /// 添加结点
        /// </summary>
        /// <param name="node">结点</param>
        public void AddNode(BoTree<String> node)
        {
            if (!nodes.Contains(node))
            {
                node.parent = this;
                nodes.Add(node);
            }
        }
        /// <summary>
        /// 添加结点
        /// </summary>
        /// <param name="nodes">结点集合</param>
        public void AddNode(List<BoTree<String>> nodes)
        {
            foreach (var node in nodes)
            {
                if (!nodes.Contains(node))
                {
                    node.parent = this;
                    nodes.Add(node);
                }
            }
        }
        /// <summary>
        /// 移除结点
        /// </summary>
        /// <param name="node"></param>
        public void Remove(BoTree<String> node)
        {
            if (nodes.Contains(node))
                nodes.Remove(node);
        }
        /// <summary>
        /// 清空结点集合
        /// </summary>
        public void RemoveAll()
        {
            nodes.Clear();
        }
        /// <summary>
        /// 查找结点
        /// </summary>
        /// <param name="nodes">结点集合</param>
        public List<BoTree<String>> getNode(BoTree<String> parent)
        {
            List<BoTree<String>> Nodes = new List<BoTree<String>>();
            foreach (var node in parent.Nodes)
            {
                Nodes.Add(node);
            }
            return Nodes;
        }
    }
}
