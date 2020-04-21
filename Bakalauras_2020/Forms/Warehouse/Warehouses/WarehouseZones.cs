using Bakalauras_2020.StaticClass;
using Bakalauras_2020.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bakalauras_2020.Forms.Warehouse.Items
{
    public partial class WarehouseZones : BTpl
    {
        public static readonly string SelectProcedure = "SelectFuncZones";
        public static readonly string DeleteProcedure = "DeleteFuncZone";

        public WarehouseZones()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            tFZoneCode.Enabled = false;
            tFZoneName.Enabled = false;
            tParentNode.Enabled = false;
            tWarehouse.Enabled = false;
            tCreated.Enabled = false;
            tUpdated.Enabled = false;
            tSpotWidth.Enabled = false;
            tSpotHeight.Enabled = false;
            tZoneLength.Enabled = false;
            tZoneRemainingVolume.Enabled = false;
            tZoneVolume.Enabled = false;
            ModifyGrid(AccessGrid());
            ModifyPanel(AccessPanel());
            ModifyTreeView();
            AccessToolStrip().Items["bDelete"].Click += WarehouseZones_Click;
        }

        private void WarehouseZones_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            Sql.ExecuteCmd(DeleteProcedure, new object[] { "@WarehouseZoneId", node.Name });
            treeView1.Nodes.Clear();
            LoadTree();
        }

        private void ModifyGrid(DataGridView dView)
        {
            dView.Visible = false;
            dView.Enabled = false;
            dView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ModifyTreeView()
        {
            LoadTree();
        }

        private void LoadTree()
        { 
            DataTable dt = Sql.GetTable(SelectProcedure, new object[] { "@WarehouseId", GlobalUser.CurrentWarehouseId });
            if (dt != null)
            {
                DataRow[] ParentNodeRows = dt.AsEnumerable().Where(x => null == x.Field<int?>("ParentId")).ToArray();

                foreach (DataRow row in ParentNodeRows)
                {
                    if (!treeView1.Nodes.ContainsKey(NullCheck.IsNullString(row["WarehouseZoneId"])))
                    {
                        treeView1.Nodes.Add(NullCheck.IsNullString(row["WarehouseZoneId"]), NullCheck.IsNullString(row["ZoneName"]));
                    }
                    else
                    {
                        TreeNode node = treeView1.Nodes.Find(NullCheck.IsNullString(row["WarehouseZoneId"]), false).FirstOrDefault();
                        node.Text = NullCheck.IsNullString(row["ZoneName"]);
                    }
                        
                }

                DataRow[] ChildNodeRows = dt.AsEnumerable().Where(x => null != x.Field<int?>("ParentId")).ToArray();

                foreach (DataRow row in ChildNodeRows)
                {
                    TreeNode node = treeView1.Nodes.Find(NullCheck.IsNullString(row["ParentId"]), false).FirstOrDefault();
                    if (node != null)
                    {
                        if (!node.Nodes.ContainsKey(NullCheck.IsNullString(row["WarehouseZoneId"])))
                            node.Nodes.Add(NullCheck.IsNullString(row["WarehouseZoneId"]), NullCheck.IsNullString(row["ZoneName"]));
                        else
                        {
                            TreeNode node_ = node.Nodes.Find(NullCheck.IsNullString(row["WarehouseZoneId"]), false).FirstOrDefault();
                            node_.Text = NullCheck.IsNullString(row["ZoneName"]);
                        }
                    }
                }
            }
            treeView1.AfterSelect += TreeView1_AfterSelect;
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string NodeKey = e.Node.Name;
            DataTable dt = Sql.GetTable("GetWarehouseZoneById", new object[] { "@WarehouseZoneId", NodeKey });
            if (dt != null)
            {
                tFZoneCode.Text = NullCheck.IsNullString(dt.Rows[0]["ZoneCode"]);
                tFZoneName.Text = NullCheck.IsNullString(dt.Rows[0]["ZoneName"]);
                tParentNode.Text = NullCheck.IsNullString(dt.Rows[0]["ParentName"]);
                tWarehouse.Text = NullCheck.IsNullString(dt.Rows[0]["WarehouseName"]);
                tCreated.Text = NullCheck.IsNullString(dt.Rows[0]["CreateDate"]);
                tUpdated.Text = NullCheck.IsNullString(dt.Rows[0]["UpdateDate"]);
                tSpotHeight.Text = NullCheck.IsNullString(dt.Rows[0]["SpotHeight"]);
                tSpotWidth.Text = NullCheck.IsNullString(dt.Rows[0]["SpotWidth"]);
                tZoneLength.Text = NullCheck.IsNullString(dt.Rows[0]["SpotLength"]);
                tZoneVolume.Text = NullCheck.IsNullString(dt.Rows[0]["SpotVolume"]);
                tZoneRemainingVolume.Text = NullCheck.IsNullString(dt.Rows[0]["SpotRemainingVolume"]);
            }
        }

        private void ModifyPanel(Panel panel)
        {
            panel.Visible = false;
            panel.Enabled = false;
        }
        private void DView_DoubleClick(object sender, EventArgs e)
        {
            AccessToolStrip().Items["bUpdate"].PerformClick();
        }

        private void ChangeButtonBehaviour(DataGridView dView)
        {
            if (dView.SelectedRows.Count > 0)
            {
                AccessToolStrip().Items["bUpdate"].Enabled = true;
            }
            else
            {
                AccessToolStrip().Items["bUpdate"].Enabled = false;
            }
        }

        public override void BeforeDataLoad()
        {
            base.BeforeDataLoad();
            SelectSql = "SelectFuncZones";
            DeleteSql = "DeleteFuncZone";
            FormMainId = "WarehouseZoneId";
            ApplyWarehouseFilter = false;
            CustomDelete = true;
        }

        public override void bAdd_Click(object sender, EventArgs e)
        {
            base.bAdd_Click(sender, e);
            WarehouseZoneEditor iEdt = new WarehouseZoneEditor();
            iEdt.FZoneParentId = GetParentNodeKey();
            if (iEdt.ShowDialog() == DialogResult.OK)
            {
                LoadTree();
            };

        }

        public override void tUpdate_Click(object sender, EventArgs e)
        {
            base.tUpdate_Click(sender, e);
            WarehouseZoneEditor iEdt = new WarehouseZoneEditor();
            iEdt.WarehouseZoneId = GetSelectedItemId();
            iEdt.FZoneParentId = GetParentNodeKey();
            if (iEdt.ShowDialog() == DialogResult.OK)
            {
                LoadTree();
            };
        }

        private int GetParentNodeKey()
        {
            return NullCheck.IsNullInt(treeView1.SelectedNode.Parent != null ? treeView1.SelectedNode.Parent.Name : treeView1.SelectedNode.Name);
        }

        private int GetSelectedItemId()
        {
            string NodeKey = treeView1.SelectedNode.Name;
            if (NodeKey == null)
            {
                MessageBox.Show("Pasirinkite eilutę, kurią norite redaguoti!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return NullCheck.IsNullInt(NodeKey);
        }
    }
}
