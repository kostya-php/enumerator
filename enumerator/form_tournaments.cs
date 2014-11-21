using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;

namespace enumerator
{
    public partial class form_tournaments : Form
    {
        public form_tournaments()
        {
            InitializeComponent();
        }

        public void tournaments_update()
        {
            this.Invoke((MethodInvoker)delegate()
            {
                dataTournaments.Rows.Clear();
            });
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();
                string query = "SELECT Count(*) FROM tournaments";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                int n = Convert.ToInt32(cmd.ExecuteScalar());
                query = "SELECT * FROM tournaments ORDER BY id ASC";
                cmd = new MySqlCommand(query, connect);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                string id, name, date, status;
                while (dataReader.Read())
                {
                    id = dataReader["id"].ToString();
                    name = dataReader["name"].ToString();
                    date = Convert.ToDateTime(dataReader["date"]).ToString("dd MMMM yyyy");
                    status = "";
                    switch (dataReader["status"].ToString())
                    {
                        case "1":
                            status = "Идут игры";
                            break;
                        case "2":
                            status = "Турнир просчитан";
                            break;
                    }
                    this.Invoke((MethodInvoker)delegate()
                    {
                        dataTournaments.Rows.Add(id, name, date, status);
                        Data.ft.Text = "Турниры (" + dataTournaments.Rows.Count.ToString() + ")";
                    });
                    Thread.Sleep(10);
                }
                dataReader.Close();

                query = "SELECT Count(*) FROM tournaments WHERE status='2'";
                cmd = new MySqlCommand(query, connect);
                int n2 = Convert.ToInt32(cmd.ExecuteScalar());
                this.Invoke((MethodInvoker)delegate()
                {
                    if (n == n2) buttonAddTournament.Enabled = true;
                    else buttonAddTournament.Enabled = false;
                });
            }
            catch (MySqlException err)
            {
                MessageBox.Show("Ошибка: " + err.ToString());
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
            this.Invoke((MethodInvoker)delegate()
            {
                if (dataTournaments.Rows.Count > 0)
                {
                    if ((dataTournaments.CurrentRow.Index + 1) == dataTournaments.Rows.Count)
                    {
                        buttonDelTournament.Enabled = true;
                    }
                    else
                    {
                        buttonDelTournament.Enabled = false;
                    }
                }
                button1.Enabled = true;
                //check_status();
            });
        }

        private void form_tournaments_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
            //this.WindowState = FormWindowState.Minimized;
        }

        private void buttonAddTournament_Click(object sender, EventArgs e)
        {
            form_add_tournament form_at = new form_add_tournament();
            form_at.Owner = this;
            form_at.ShowDialog();
        }

        private void buttonDelTournament_Click(object sender, EventArgs e)
        {
            int index = dataTournaments.CurrentRow.Index;
            int id = Convert.ToInt32(dataTournaments[0, index].Value);
            DialogResult dr = MessageBox.Show("\"" + dataTournaments[1, index].Value.ToString() + "\"" + Environment.NewLine + "Вы действительно хотите удалить этот турнир?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                MySqlConnection connect = null;
                try
                {
                    connect = new MySqlConnection(Data.connectionString);
                    connect.Open();
                    // Удаляем турнир
                    string query = "DELETE FROM tournaments WHERE id='" + id.ToString() + "'";
                    MySqlCommand cmd = new MySqlCommand(query, connect);
                    cmd.ExecuteNonQuery();
                    query = "ALTER TABLE tournaments AUTO_INCREMENT=0";
                    cmd = new MySqlCommand(query, connect);
                    cmd.ExecuteNonQuery();
                    // Удаляем игроков с турнира
                    query = "DELETE FROM in_tournament WHERE tournament='" + id.ToString() + "'";
                    cmd = new MySqlCommand(query, connect);
                    cmd.ExecuteNonQuery();
                    query = "ALTER TABLE in_tournament AUTO_INCREMENT=0";
                    cmd = new MySqlCommand(query, connect);
                    cmd.ExecuteNonQuery();
                    // Делаем выборку игр
                    query = "SELECT * FROM matches WHERE tournament='" + id.ToString() + "'";
                    cmd = new MySqlCommand(query, connect);
                    MySqlDataReader dataReader2 = cmd.ExecuteReader();
                    // И удаляем партии
                    int match;
                    string queries = "";
                    while (dataReader2.Read())
                    {
                        match = Convert.ToInt32(dataReader2["id"]);
                        queries += "DELETE FROM rounds WHERE `match`='" + match.ToString() + "';";
                    }
                    dataReader2.Close();
                    cmd = new MySqlCommand(queries, connect);
                    cmd.ExecuteNonQuery();
                    query = "ALTER TABLE rounds AUTO_INCREMENT=0";
                    cmd = new MySqlCommand(query, connect);
                    cmd.ExecuteNonQuery();
                    // Удаляем игры
                    query = "DELETE FROM matches WHERE tournament='" + id.ToString() + "'";
                    cmd = new MySqlCommand(query, connect);
                    cmd.ExecuteNonQuery();
                    query = "ALTER TABLE matches AUTO_INCREMENT=0";
                    cmd = new MySqlCommand(query, connect);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException err)
                {
                    MessageBox.Show("Ошибка: " + err.ToString());
                }
                finally
                {
                    if (connect != null)
                    {
                        connect.Close();
                    }
                }
                //tournaments_update();
                //matches_update();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Thread myThread = new Thread(tournaments_update);
            myThread.Start();
        }

        private void form_tournaments_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Thread myThread = new Thread(tournaments_update);
            myThread.Start();
        }

        private void dataTournaments_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Index == 0)
            {
                e.SortResult = int.Parse(e.CellValue1.ToString()).CompareTo(int.Parse(e.CellValue2.ToString()));
                e.Handled = true;
            }
        }        
        
        private void uncalc_tournament(int t)
        {
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();
                string query = "";
                query += "DELETE FROM results WHERE tournament='" + t.ToString() + "';";
                query += "ALTER TABLE results AUTO_INCREMENT=0;";
                query += "UPDATE tournaments SET status='1' WHERE id='" + t.ToString() + "';";
                query += "DELETE FROM penalties WHERE tournament='" + t.ToString() + "';";
                query += "ALTER TABLE penalties AUTO_INCREMENT=0;";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                MessageBox.Show("Ошибка: " + err.ToString());
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }
        private void calc_player(int id, int t)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Data.fc.ShowDialog();
        }
        /*
        private void calc_tournament(int t, int[] places)
        {
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();

                string q1 = "SELECT * FROM in_tournament WHERE tournament='" + t.ToString() + "' ORDER BY number ASC";
                MySqlCommand cmd1 = new MySqlCommand(q1, connect);
                MySqlDataReader dataReader1 = cmd1.ExecuteReader();
                while (dataReader1.Read())
                {
                    int id = Convert.ToInt32(dataReader1["player"]);
                    int number = Convert.ToInt32(dataReader1["number"]);
                    double rating_prev = get_r(id, t, true);

                    string q2 = "SELECT * FROM matches WHERE (player1='" + id.ToString() + "' OR player2='" + id.ToString() + "') AND tournament='" + t.ToString() + "' ORDER BY id ASC";
                    //$main->sql_query['get_new_r'] = "SELECT * FROM matches WHERE (player1='$id' OR player2='$id') AND tournament='$t' ORDER BY id ASC";
                    MySqlCommand cmd2 = new MySqlCommand(q2, connect);
                    MySqlDataReader dataReader2 = cmd2.ExecuteReader();
                    int points = 0;
                    double delta = 0;
                    string note = null;
                    int place = places[id];
                    string query = "";
                    double K = 0.1; //$K = $main->get_k($t); ДОДЕЛАТЬ
                    double RTV, RTP, temp = 0, rating_cur;
                    while (dataReader2.Read())
                    {
                        // Если текущий игрок - player1
                        if (Convert.ToInt32(dataReader2["player1"]) == id)
                        {
                            // Если текущий игрок выйграл
                            if (Convert.ToInt32(dataReader2["x"]) > Convert.ToInt32(dataReader2["y"]))
                            {
                                RTV = get_r(Convert.ToInt32(dataReader2["player1"]), t, true);
                                RTP = get_r(Convert.ToInt32(dataReader2["player2"]), t, true);
                                if (RTV - RTP > 100) temp = 0;
                                else temp = (100 - (RTV - RTP)) / 10;
                                points += 2;
                                //$r2 = $main->get_r($row2['player2'],$t,true);
                                //$temp = ((100 - $rating_prev + $r2) / 10);
                                //$line = "$k. выйграл игрока ".$main->player_name($row2['player2'])." (Р:$r2);(100 - ".$rating_prev." + ".$r2.") / 10 = ".$temp;
                                //$note.=$line.";;";
                                //$k++;
                            }
                            else
                                // Если текущий игрок проиграл
                                if (Convert.ToInt32(dataReader2["x"]) < Convert.ToInt32(dataReader2["y"]))
                                {
                                    RTV = get_r(Convert.ToInt32(dataReader2["player2"]), t, true);
                                    RTP = get_r(Convert.ToInt32(dataReader2["player1"]), t, true);
                                    temp = -(100 - (RTV - RTP)) / 20;
                                    points += 1;
                                    //$r2 = $main->get_r($row2['player2'],$t,true);
                                    //$temp = -((100 - $r2 + $rating_prev) / 20);
                                    //$line = "$k. проиграл игроку ".$main->player_name($row2['player2'])." (Р:$r2);-(100 - ".$r2." + ".$rating_prev.") / 20 = ".$temp;
                                    //$note.=$line.";;";
                                    //$k++;
                                }
                            delta += temp;
                        }
                        else
                            // Если текущий игрок - player2
                            if (Convert.ToInt32(dataReader2["player2"]) == id)
                            {
                                // Если текущий игрок выйграл		
                                if (Convert.ToInt32(dataReader2["y"]) > Convert.ToInt32(dataReader2["x"]))
                                {
                                    RTV = get_r(Convert.ToInt32(dataReader2["player2"]), t, true);
                                    RTP = get_r(Convert.ToInt32(dataReader2["player1"]), t, true);
                                    if (RTV - RTP > 100) temp = 0;
                                    else temp = (100 - (RTV - RTP)) / 10;
                                    points += 2;
                                    //$r2 = $main->get_r($row2['player1'],$t,true);
                                    //$temp = ((100 - $r2 + $rating_prev) / 10);
                                    //$line = "$k. выйграл игрока ".$main->player_name($row2['player1'])." (Р:$r2);(100 - ".$r2." + ".$rating_prev.") / 10 = ".$temp;
                                    //$note.=$line.";;";
                                    //$k++;
                                }
                                else
                                    // Если текущий игрок проиграл
                                    if (Convert.ToInt32(dataReader2["y"]) < Convert.ToInt32(dataReader2["x"]))
                                    {
                                        RTV = get_r(Convert.ToInt32(dataReader2["player1"]), t, true);
                                        RTP = get_r(Convert.ToInt32(dataReader2["player2"]), t, true);
                                        temp = -(100 - (RTV - RTP)) / 20;
                                        points += 1;
                                        //$r2 =  $main->get_r($row2['player1'],$t,true);
                                        //$temp = -((100 - $rating_prev + $r2) / 20);
                                        //$line = "$k. проиграл игроку ".$main->player_name($row2['player1'])." (Р:$r2);-(100 - ".$rating_prev." + ".$r2.") / 20 = ".$temp;
                                        //$note.=$line.";;";
                                        //$k++;
                                    }
                                delta += temp;
                            }
                    }
                    delta = K * delta;
                    //$delta = $delta*100;
                    //$delta = floor($delta);
                    //$delta = $delta/100;
                    //delta = round(delta,1); //???????
                    rating_cur = delta + rating_prev;
                    query += "INSERT INTO results VALUES(null,'" + t.ToString() + "','" + id.ToString() + "','" + points.ToString() + "','" + note + "','" + rating_prev.ToString() + "','" + delta.ToString() + "',null,null,'" + rating_cur.ToString() + "','" + place.ToString() + "')";
                    //$main->sql_query['q'.$id] = "INSERT INTO results VALUES(null,'$t','$id','$points',null,'$rating_prev','$delta',null,null,'$rating_cur','$place')";
                    //$main->sql_execute('q'.$id);
                    MySqlCommand cmd3 = new MySqlCommand(query, connect);
                    cmd3.ExecuteNonQuery();
                    //echo($query[$id-1]."<br />");
                    //echo("<hr>");
                    //echo($row['number'].". ".$main->player_name($row['player'])." ".$main->get_delta($row['player'],23)."<br />");
                }
                dataReader1.Close();
                string q4 = "UPDATE tournaments SET status='3' WHERE id='$t'";
                MySqlCommand cmd4 = new MySqlCommand(q4, connect);
                cmd4.ExecuteNonQuery();
                /*
                 * 
                 * ДОДЕЛАТЬ
                 * 
                $players = $main->get_penalties($t);
                for($i=0;$i<count($players);$i++) {
                    $p = $players[$i];
                    $main->sql_query[$p] = "INSERT INTO penalties VALUES (null,'$p','$t','-1.0')";
                    $main->sql_execute($p);
                }
				
                $main->update_players();
                Header("Location: edit_tournament.php?id=".$t);
                 
            }
            catch (MySqlException err)
            {
                MessageBox.Show("Ошибка: " + err.ToString());
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }*/

        /*
        private double get_r(int id, int t, bool update)
        {
            int result = 0;
            // выравниваем
            t++;
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();
                if (get_tournaments(id, t) > 0)
                {
                    string q1 = "SELECT * FROM players WHERE id='" + id.ToString() + "'";
                    MySqlCommand cmd1 = new MySqlCommand(q1, connect);
                    int n = Convert.ToInt32(cmd1.ExecuteScalar());
                    if (n > 0)
                    {
                        MySqlDataReader dataReader1 = cmd1.ExecuteReader();
                        while (dataReader1.Read())
                        {
                            result += Convert.ToInt32(dataReader1["base_rating"]);
                        }
                    }
                    string query2 = "SELECT * FROM results WHERE player='" + id.ToString() + "' AND tournament<'" + t.ToString() + "'";
                    MySqlCommand cmd2 = new MySqlCommand(query2, connect);
                    n = Convert.ToInt32(cmd2.ExecuteScalar());

                    if (n >= 0)
                    {
                        MySqlDataReader dataReader2 = cmd2.ExecuteReader();
                        while (dataReader2.Read())
                        {
                            result += Convert.ToInt32(dataReader2["increment"]);//$row['increment'];
                            //Раскомментировать, если будут использоваться бонусы(за выйгранну партию при проигрыше) и штрафы(за проигранную партию при выйгрыше)
                            //$result+=$row['bonus']+$row['penalty'];
                            result += get_penalty(id, (t - 1));
                        }
                    }
                }
                else
                {
                    if (update == true)
                    {
                        string query3 = "SELECT * FROM players WHERE id='" + id.ToString() + "'";
                        MySqlCommand cmd3 = new MySqlCommand(query3, connect);
                        int n = Convert.ToInt32(cmd3.ExecuteScalar());
                        if (n > 0)
                        {
                            MySqlDataReader dataReader3 = cmd3.ExecuteReader();
                            while (dataReader3.Read())
                            {
                                result += Convert.ToInt32(dataReader3["base_rating"]);
                            }
                        }
                        //$result = 100;
                    }
                }
                //if(!(is_float($result))and($result!=0)) $result.=".0"; // ??????
                //$result = (float) $result;
                //if($result == 0) return null; else
            }
            catch (MySqlException err)
            {
                MessageBox.Show("Ошибка: " + err.ToString());
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
            return result;
        }



        // Получаем количество проведенных игроком турниров (по номеру в таблице results)
        private int get_tournaments(int id, int t)
        {
            int result = 0;
            t++;
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();

                string query = "SELECT * FROM results WHERE player='" + id.ToString() + "' AND tournament<'" + t.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (MySqlException err)
            {
                MessageBox.Show("Ошибка: " + err.ToString());
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
            return result;
        }
        // Получаем штраф игрока за определенный турнир (если есть)
        private int get_penalty(int id, int t)
        {
            int result = 0;
            MySqlConnection connect = null;
            try
            {
                connect = new MySqlConnection(Data.connectionString);
                connect.Open();
                string query = "SELECT * FROM penalties WHERE player='" + id.ToString() + "' AND tournament='" + t.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                int n = Convert.ToInt32(cmd.ExecuteScalar());
                if (n > 0)
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        result = Convert.ToInt32(dataReader["penalty"]);
                    }
                }
            }
            catch (MySqlException err)
            {
                MessageBox.Show("Ошибка: " + err.ToString());
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
            return result;
        }
        */
    }
}
