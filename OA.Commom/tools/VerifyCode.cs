using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OA.Commom.ParamModel;
using OA.Commom.Cache;
using System.IO;
using System.Drawing.Imaging;

namespace OA.Commom.tools
{
    public class VerifyCode
    {
         //获取验证码
        public byte[] GetVerifyCode(VerifyCodeParam verifyCodeParam)
        {
            int codeW = verifyCodeParam.CodeWidth;//长
            int codeH = verifyCodeParam.CodeHeight;//宽
            int fontSize = verifyCodeParam.FontSize;//字体大小
            Color[] colors = verifyCodeParam.Colors;//颜色
            string[] fonts = verifyCodeParam.Fonts;//字体
            char[] characters = verifyCodeParam.characters;//字符
            int codeLength=verifyCodeParam.CodeLength;//验证码长度
            int interLineCount=verifyCodeParam.InterLineCount;//噪线数量

            //验证码字符串
            string chkCode = string.Empty;
            Random rnd = new Random();
            for (int i = 0; i < codeLength; i++)
            {
                chkCode += characters[rnd.Next(characters.Length)];
            }
            //存入缓存中
            CacheHelper.SetCache("verifyCode",chkCode);
            string aa=CacheHelper.GetCache("verifyCode").ToString();
            //创建画布
            Bitmap bm = new Bitmap(codeW, codeH);
            Graphics g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            //画噪线
            for (int i = 0; i < interLineCount; i++)
            {
                int x1 = rnd.Next(codeW);
                int y1 = rnd.Next(codeH);
                int x2 = rnd.Next(codeW);
                int y2 = rnd.Next(codeH);
                Color clr = colors[rnd.Next(colors.Length)];
                g.DrawLine(new Pen(clr), x1, y1, x2, y2);
            }
            //画验证码字符串
            for (int i = 0; i < codeLength; i++)
            {
                string fnt = fonts[rnd.Next(fonts.Length)];
                Font ft = new Font(fnt, fontSize);
                Color clr = colors[rnd.Next(colors.Length)];
                g.DrawString(chkCode[i].ToString(), ft, new SolidBrush(clr), (float)(i * (fontSize+2)), (float)0);
            }
            MemoryStream ms = new MemoryStream();
            try
            {
                bm.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                g.Dispose();
                bm.Dispose();
            }
        }
    }
}
