using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScribeBot.Wrappers
{
    /// <summary>
    /// Class containing all functions that can and should be implemented from Lua environment itself.
    /// </summary>
    static class LuaExtensions
    {
        public static string Code =
        @"
            function wait(time)
                local callTime = os.clock() + (time/1000)
                repeat until os.clock() > callTime
            end

            --[[
            TABLE.PRINT(TABLE):
                - Takes one argument (other two are for internal use).
                - Recursively pretty prints a table, formatted with 'INDEX: [TYPE] VALUE'
            ]]
            function table.print(t, iteration, t_colon)
            
                -- Variable setup,
                local iteration = iteration or 0
                local t_colon = t_colon or ''
                local count = 1
                
                -- Print initial `{`,
                print(string.format('%' .. iteration * 2 .. 's{', ''))
                
                -- Loop through every element and print it accordingly,
                for key, value in pairs(t) do
                    -- Test weather this is the last element, if so, remove colon,
                    local colon = ','
                    if count == #t then
                    colon = ''
                    end
                    
                    -- Check types, and print it accordingly,
                    if type(value) == 'table' then
                    table.print(value, iteration + 1, colon)
                    elseif type(value) == 'string' then
                    print(string.format('%' .. (iteration + 1) * 2 .. 's' .. key .. ': ' .. '[' .. type(value) .. '] \'' .. value .. '\'' .. colon, ''))
                    elseif type(value) == 'number' then
                    print(string.format('%' .. (iteration + 1) * 2 .. 's' .. key .. ': ' .. '[' .. type(value) .. '] ' .. value .. '' .. colon, ''))
                    elseif type(value) == 'boolean' then
                    print(string.format('%' .. (iteration + 1) * 2 .. 's' .. key .. ': ' .. '[' .. type(value) .. '] ' .. tostring(value) .. '' .. colon, ''))
                    else
                    print(string.format('%' .. (iteration + 1) * 2 .. 's' .. key .. ': ' .. '[' .. type(value) .. '] ' .. tostring(value) .. '' .. colon, ''))
                    end
                    count = count + 1
                end
                
                -- Print last `}`,
                print(string.format('%' .. iteration * 2 .. 's}' .. t_colon, ''))
                
            end

    }
}
