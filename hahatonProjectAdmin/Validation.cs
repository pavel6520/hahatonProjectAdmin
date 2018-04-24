using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hahatonProjectAdmin
{
    static class Validation
    {
        static string IntString = "0123456789";
        static string DoubleString = ",";
        static string LoginString = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM-_";
        static string PasswordString = "#$&@?%";
        static string CompNameString = "йцукенгшщзхъфывапролджэячсмитьбюёЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁ~!\"'*()+=[]{}\\|/,.";

        public enum ValidationType
        {
            IntType,
            DoubleType,
            LoginType,
            PasswordType,
            CompNameType
        }

        /// <summary>
        /// Проверка корректности введеного символа в зависимости от требований
        /// </summary>
        /// <param name="TypeValid">Тип проверки</param>
        /// <param name="CharBuf">Символ для проверки</param>
        /// <param name="CopyMode">Разрешение копирования комбинацией клавиш Ctrl+C</param>
        /// <param name="PasteMode">Разрешение вставки комбинацией клавиш Ctrl+V</param>
        public static bool CharValidation(ValidationType TypeValid, char CharBuf, bool CopyMode = false, bool PasteMode = false)
        {
            if (CopyMode && CharBuf == 3) return true;
            if (PasteMode && CharBuf == 22) return true;
            switch (TypeValid)
            {
                case ValidationType.IntType: //Проверка на корректность целого числа
                    {
                        return IntValidation(CharBuf);
                    }
                case ValidationType.DoubleType: //Проверка на корректность дробного числа
                    {
                        return DoubleValidation(CharBuf);
                    }
                case ValidationType.LoginType: //Проверка на корректность логина
                    {
                        return LoginValidation(CharBuf);
                    }
                case ValidationType.PasswordType: //Проверка на корректность пароля
                    {
                        return PasswordValidation(CharBuf);
                    }
                case ValidationType.CompNameType: //Проверка на корректность имени компании
                    {
                        return CompNameValidation(CharBuf);
                    }
                default: return false;
            }
        }

        /// <summary>
        /// Проверка корректности введеной строки в зависимости от требований
        /// </summary>
        /// <param name="ValidationType">Тип проверки</param>
        /// <param name="StringBuf">Строка для проверки</param>
        public static bool StringValidation(ValidationType TypeValid, string StringBuf)
        {
            switch (TypeValid)
            {
                case ValidationType.IntType: //Проверка на корректность целого числа
                    {
                        for (int i = 0; i < StringBuf.Length; i++)
                        {
                            if (!IntValidation(StringBuf[i]))
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                case ValidationType.DoubleType: //Проверка на корректность дробного числа
                    {
                        for (int i = 0; i < StringBuf.Length; i++)
                        {
                            if (!DoubleValidation(StringBuf[i]))
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                case ValidationType.LoginType: //Проверка на корректность логина
                    {
                        for (int i = 0; i < StringBuf.Length; i++)
                        {
                            if (!LoginValidation(StringBuf[i]))
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                case ValidationType.PasswordType: //Проверка на корректность пароля
                    {
                        for (int i = 0; i < StringBuf.Length; i++)
                        {
                            if (!PasswordValidation(StringBuf[i]))
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                case ValidationType.CompNameType: //Проверка на корректность имени компании
                    {
                        for (int i = 0; i < StringBuf.Length; i++)
                        {
                            if (!CompNameValidation(StringBuf[i]))
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                default: return false;
            }
        }

        private static bool IntValidation(char CharBuf)
        {
            return IntString.IndexOf(CharBuf) != -1;
        }

        private static bool DoubleValidation(char CharBuf)
        {
            return DoubleString.IndexOf(CharBuf) != -1 || IntValidation(CharBuf);
        }

        private static bool LoginValidation(char CharBuf)
        {
            return LoginString.IndexOf(CharBuf) != -1 || IntValidation(CharBuf);
        }

        private static bool PasswordValidation(char CharBuf)
        {
            return PasswordString.IndexOf(CharBuf) != -1 || LoginValidation(CharBuf);
        }

        private static bool CompNameValidation(char CharBuf)
        {
            return CompNameString.IndexOf(CharBuf) != -1 || PasswordValidation(CharBuf);
        }
    }
}
